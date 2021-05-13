using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Parsers;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary
{
	public static class Library
	{
		private static Dictionary<string, string> EbxNameTypes;

		private static Dictionary<string, Guid> EbxNameGuid;

		internal static Dictionary<string, EbxRef> AllEbx;

		internal static Dictionary<long, ResRef> AllRes;

		internal static Dictionary<Guid, ChunkRef> AllChunks;

		internal static Dictionary<string, SubBundleRef> AllSubBundles;

		internal static List<GameAssetFolder> GameAssetFolders;

		internal static Dictionary<Guid, EbxRef> EbxGuidLookup;

		internal static Dictionary<string, EbxRef> EbxNameSha1Lookup;

		private static Dictionary<string, ResRef> ResNameLookup;

		public static List<AssetEntryRef> ModifiedEntries;

		public static string DefaultLanguage = "en";

		public static int PatchVersion = -1;

		public static LibraryEventManager EventManager = new LibraryEventManager();

		internal static Dictionary<string, CatalogEntry> CasEntries { get; private set; }

		internal static Dictionary<Guid, string> PlotFlagTable { get; private set; }

		internal static Dictionary<string, Dictionary<uint, Talktable.TalktableString>> StringTable { get; private set; }

		internal static Dictionary<int, string> EventTable { get; private set; }

		internal static string BasePath { get; private set; }

		public static void Init(string basePath)
		{
			if (basePath.EndsWith("\\"))
			{
				basePath = basePath.Substring(0, basePath.Length - 1);
			}
			BasePath = basePath;
			GameAssetFolders = new List<GameAssetFolder>();
			BuildFolders();
		}

		internal static void InitLibrary()
		{
			ModifiedEntries = new List<AssetEntryRef>();
			EbxNameTypes = new Dictionary<string, string>();
			EbxNameGuid = new Dictionary<string, Guid>();
			ResNameLookup = new Dictionary<string, ResRef>();
			EbxNameSha1Lookup = new Dictionary<string, EbxRef>();
			EventTable = new Dictionary<int, string>();
			StringTable = new Dictionary<string, Dictionary<uint, Talktable.TalktableString>>();
			PlotFlagTable = new Dictionary<Guid, string>();
			EbxGuidLookup = new Dictionary<Guid, EbxRef>();
			AllChunks = new Dictionary<Guid, ChunkRef>();
			AllRes = new Dictionary<long, ResRef>();
			AllEbx = new Dictionary<string, EbxRef>();
			AllSubBundles = new Dictionary<string, SubBundleRef>();
			LoadPlotFlags();
			LoadFieldNames();
			LoadEbxNameTypes();
			CasEntries = GameAssetFolders.SelectMany((GameAssetFolder folder) => CatalogParser.ParseAll(Path.Combine(BasePath, folder.Path))).ToDictionary((KeyValuePair<string, CatalogEntry> pair) => pair.Key, (KeyValuePair<string, CatalogEntry> pair) => pair.Value);
		}

		public static void BuildLibrary()
		{
			InitLibrary();
			try
			{
				DateTime startDate = DateTime.Now;
				int count = 0;
				foreach (GameAssetFolder folder in GameAssetFolders)
				{
					string[] tocs = Directory.GetFiles(Path.Combine(Path.Combine(BasePath, folder.Path), "Win32"), "*.toc", SearchOption.AllDirectories);
					EventManager.OnBeginGameFolderParsing(folder.Path, tocs.Length);
					string[] array = tocs;
					foreach (string tocFile in array)
					{
						EventManager.OnBeginTocParsing(tocFile.Replace(BasePath, ""));
						DateTime start = DateTime.Now;
						TableOfContentRef toc = TocParser.ParseToc(tocFile, BasePath, folder.FolderType);
						(DateTime.Now - start).ToDebugWindow("read toc and children bundles");
						CleanEntries(toc, folder.FolderType == FolderType.DLC);
						count++;
						if (count % 50 == 0)
						{
							GC.Collect();
						}
					}
				}
				WriteEbxNameTypes();
				(DateTime.Now - startDate).ToDebugWindow("build library");
				LoadTalktables(ResNameLookup.Values.Where((ResRef x) => x.ResType == 1585851909).ToList());
			}
			catch (Exception)
			{
			}
		}

		private static void BuildFolders()
		{
			string[] files = Directory.GetFiles(BasePath, "*.cat", SearchOption.AllDirectories);
			for (int i = 0; i < files.Length; i++)
			{
				string dirPath2 = Path.GetDirectoryName(files[i]);
				if (Directory.GetParent(dirPath2).FullName == BasePath)
				{
					GameAssetFolders.Add(new GameAssetFolder(dirPath2.Replace(BasePath + "\\", ""), FolderType.MainData));
					break;
				}
			}
			List<Tuple<int, GameAssetFolder>> patchCandidates = new List<Tuple<int, GameAssetFolder>>();
			files = Directory.GetFiles(BasePath, "package.mft", SearchOption.AllDirectories);
			foreach (string obj in files)
			{
				string dirPath = Path.GetDirectoryName(obj);
				Mft manifest = Mft.SerializeFromFile(obj);
				if (manifest.HasKey("ModManager"))
				{
					continue;
				}
				if (!manifest.HasKey("Authoritative"))
				{
					GameAssetFolders.Add(new GameAssetFolder(dirPath.Replace(BasePath + "\\", "") + "\\Data", FolderType.DLC));
					continue;
				}
				int version = 0;
				if (manifest.HasKey("Version"))
				{
					version = Convert.ToInt32(manifest.GetValue("Version"));
				}
				PatchVersion = Math.Max(PatchVersion, version);
				patchCandidates.Add(new Tuple<int, GameAssetFolder>(version, new GameAssetFolder(dirPath.Replace(BasePath + "\\", "") + "\\Data", FolderType.OfficialPatch)));
			}
			Tuple<int, GameAssetFolder> rightPatch = patchCandidates.FirstOrDefault((Tuple<int, GameAssetFolder> pair) => pair.Item1 == PatchVersion);
			if (rightPatch != null)
			{
				GameAssetFolders.Add(rightPatch.Item2);
			}
			GameAssetFolders.Sort((GameAssetFolder A, GameAssetFolder B) => A.FolderType - B.FolderType);
		}

		private static void CleanEntries(TableOfContentRef toc, bool isAddonContent)
		{
			CleanChunks(toc, isAddonContent);
			CleanRes(toc, isAddonContent);
			CleanEbx(toc, isAddonContent);
		}

		private static void CleanChunks(TableOfContentRef toc, bool isAddonContent)
		{
			List<ChunkRef> list = new List<ChunkRef>(toc.Chunks.ToArray());
			toc.Chunks.Clear();
			foreach (ChunkRef chunk2 in list)
			{
				chunk2.EntryPath = toc.EntryPath;
				chunk2.FromDLC = isAddonContent;
				if (chunk2.ChunkId == Guid.Empty)
				{
					chunk2.ChunkId = new Guid(chunk2.Id);
				}
				if (!toc.Cas)
				{
					chunk2.Sha1 = string.Empty;
				}
				else if (!CasEntries.ContainsKey(chunk2.Sha1))
				{
					continue;
				}
				if (!AllChunks.ContainsKey(chunk2.ChunkId))
				{
					AllChunks.Add(chunk2.ChunkId, chunk2);
				}
			}
			foreach (SubBundleRef curSb in toc.SubBundles)
			{
				List<ChunkRef> list2 = new List<ChunkRef>(curSb.Chunks.ToArray());
				curSb.Chunks.Clear();
				SubBundleRef sb = AddSubBundle(curSb);
				foreach (ChunkRef chunk in list2)
				{
					chunk.EntryPath = curSb.EntryPath;
					chunk.FromDLC = isAddonContent;
					if (chunk.ChunkId == Guid.Empty)
					{
						chunk.ChunkId = new Guid(chunk.Id);
					}
					if (!CasEntries.ContainsKey(chunk.Sha1))
					{
						chunk.Sha1 = string.Empty;
					}
					if (!AllChunks.ContainsKey(chunk.ChunkId))
					{
						AllChunks.Add(chunk.ChunkId, chunk);
						AddToBundle(chunk, sb);
					}
					else
					{
						AddToBundle(AllChunks[chunk.ChunkId], sb);
					}
				}
			}
		}

		private static void CleanRes(TableOfContentRef toc, bool isAddonContent)
		{
			foreach (SubBundleRef curSb in toc.SubBundles)
			{
				List<ResRef> list = new List<ResRef>(curSb.Res.ToArray());
				curSb.Res.Clear();
				SubBundleRef sb = AddSubBundle(curSb);
				foreach (ResRef res in list)
				{
					res.EntryPath = curSb.EntryPath;
					res.FromDLC = isAddonContent;
					if (!toc.Cas)
					{
						res.Sha1 = string.Empty;
					}
					if (curSb.Delta && res.CasPatchType == 2)
					{
						res.IsDelta = true;
					}
					else if (!string.IsNullOrEmpty(res.Sha1) && !CasEntries.ContainsKey(res.Sha1))
					{
						continue;
					}
					ResRef oldRes = null;
					if (res.ResRid == 0L)
					{
						oldRes = GetResByName(res.Name);
						if (oldRes == null)
						{
							continue;
						}
						res.ResRid = oldRes.ResRid;
					}
					else if (AllRes.ContainsKey(res.ResRid))
					{
						oldRes = AllRes[res.ResRid];
					}
					if (oldRes != null)
					{
						if (res.IsDelta)
						{
							foreach (SubBundleRef otherSb in new List<SubBundleRef>(oldRes.ParentSbs.ToArray()))
							{
								RemoveFromBundle(otherSb, oldRes);
								AddToBundle(res, otherSb);
							}
							RemoveRes(oldRes);
							AddRes(res);
							AddToBundle(res, sb);
						}
						else
						{
							AddToBundle(oldRes, sb);
						}
					}
					else
					{
						res.CasPatchType = 7;
						AddRes(res);
						AddToBundle(res, sb);
					}
				}
			}
		}

		private static void CleanEbx(TableOfContentRef toc, bool isAddonContent)
		{
			foreach (SubBundleRef curSb in toc.SubBundles)
			{
				List<EbxRef> list = new List<EbxRef>(curSb.Ebx.ToArray());
				curSb.Ebx.Clear();
				SubBundleRef sb = AddSubBundle(curSb);
				foreach (EbxRef ebx in list)
				{
					ebx.EntryPath = curSb.EntryPath;
					ebx.FromDLC = isAddonContent;
					if (!toc.Cas)
					{
						ebx.Sha1 = string.Empty;
					}
					if (curSb.Delta && ebx.CasPatchType == 2)
					{
						ebx.IsDelta = true;
					}
					else if (!string.IsNullOrEmpty(ebx.Sha1) && !CasEntries.ContainsKey(ebx.Sha1))
					{
						continue;
					}
					
					if (AllEbx.ContainsKey(ebx.Name))
					{
						EbxRef oldEbx = AllEbx[ebx.Name];
						if (oldEbx.IsDelta || !ebx.IsDelta)
						{
							if (string.IsNullOrEmpty(oldEbx.Sha1) && !string.IsNullOrEmpty(ebx.Sha1) && curSb.Delta)
                            {
								oldEbx.Sha1 = ebx.Sha1;
                            }
							AddToBundle(oldEbx, sb);
							continue;
						}
						RemoveEbx(oldEbx);
						foreach (SubBundleRef otherSb in new List<SubBundleRef>(oldEbx.ParentSbs.ToArray()))
						{
							RemoveFromBundle(otherSb, oldEbx);
							AddToBundle(ebx, otherSb);
						}
					}
					if (GetEbxBaseInfos(ebx))
					{
						AddEbx(ebx);
						AddToBundle(ebx, sb);
					}
				}
			}
		}

		private static bool GetEbxBaseInfos(EbxRef ebxRef)
		{
			string ebxType = null;
			EbxBase dEbx = null;
			if (!EbxNameTypes.ContainsKey(ebxRef.Name))
			{
				dEbx = EbxBase.DoQuickLookup(ebxRef, ref ebxType);
				if (dEbx == null)
				{
					return false;
				}
				EbxNameTypes.Add(ebxRef.Name, ebxType);
				EbxNameGuid.Add(ebxRef.Name, dEbx.FileGuid);
			}
			ebxRef.FileGuid = EbxNameGuid[ebxRef.Name];
			ebxRef.AssetType = EbxNameTypes[ebxRef.Name];
			return true;
		}

		private static void LoadTalktables(List<ResRef> talkTableRes)
		{
			StringTable = new Dictionary<string, Dictionary<uint, Talktable.TalktableString>>();
			foreach (ResRef resEntry in talkTableRes)
			{
				int num = resEntry.Name.IndexOf("texttable/") + 10;
				string LangID = resEntry.Name.Substring(num, resEntry.Name.IndexOf("/", num) - num);
				try
				{
					Talktable talktable = Talktable.FromRes(resEntry);
					if (talktable == null || talktable.Strings == null)
					{
						continue;
					}
					foreach (Talktable.TalktableString @string in talktable.Strings)
					{
						AddString(LangID, @string);
					}
				}
				catch (Exception)
				{
				}
			}
		}

		private static void LoadFieldNames()
		{
			Assembly a = Assembly.GetExecutingAssembly();
			string name = a.GetName().Name;
			try
			{
				using (Stream s = a.GetManifestResourceStream(name + ".Resources.FieldNames.txt"))
				{
					using (StreamReader sReader = new StreamReader(s))
					{
						while (!sReader.EndOfStream)
						{
							string[] values = sReader.ReadLine().Split(',');
							if (values != null && values.Length == 2)
							{
								int hash = int.Parse(values[0], NumberStyles.HexNumber);
								if (!EventTable.ContainsKey(hash))
								{
									EventTable.Add(hash, values[1]);
								}
							}
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private static void LoadEbxNameTypes()
		{
			if (!File.Exists("EbxNameTypes.txt"))
			{
				return;
			}
			try
			{
				byte[] data = null;
				using (FileStream fs = new FileStream("EbxNameTypes.txt", FileMode.Open, FileAccess.Read))
				{
					using (BinaryReader binaryReader = new BinaryReader(fs))
					{
						data = DAI.AssetLibrary.Utilities.Utilities.DecompressData(binaryReader.ReadBytes((int)binaryReader.BaseStream.Length), -1L);
					}
				}
				using (MemoryStream ms = new MemoryStream(data))
				{
					using (StreamReader reader = new StreamReader(ms))
					{
						while (!reader.EndOfStream)
						{
							string[] values = reader.ReadLine().Split(';');
							EbxNameTypes.Add(values[0], values[1]);
							EbxNameGuid.Add(values[0], new Guid(values[2]));
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private static void WriteEbxNameTypes()
		{
			byte[] data = null;
			using (MemoryStream ms = new MemoryStream())
			{
				using (StreamWriter streamWriter = new StreamWriter(ms))
				{
					foreach (KeyValuePair<string, string> values in EbxNameTypes)
					{
						streamWriter.WriteLine($"{values.Key};{values.Value};{EbxNameGuid[values.Key]}");
					}
				}
				data = DAI.AssetLibrary.Utilities.Utilities.CompressData(ms.ToArray());
			}
			using (FileStream fs = new FileStream("EbxNameTypes.txt", FileMode.Create))
			{
				using (BinaryWriter writer = new BinaryWriter(fs))
				{
					writer.Write(data);
				}
			}
			EbxNameGuid.Clear();
			EbxNameGuid = null;
			EbxNameTypes.Clear();
			EbxNameTypes = null;
		}

		private static void LoadPlotFlags()
		{
			PlotFlagTable = new Dictionary<Guid, string>();
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string name = executingAssembly.GetName().Name;
			using (Stream s = executingAssembly.GetManifestResourceStream(name + ".Resources.PlotFlags.txt"))
			{
				using (StreamReader sReader = new StreamReader(s))
				{
					while (!sReader.EndOfStream)
					{
						string[] strArrays2 = sReader.ReadLine().Split(',');
						byte[] numArray = new byte[16];
						for (int p = 0; p < strArrays2[0].Length; p += 2)
						{
							byte num7 = byte.Parse(strArrays2[0].Substring(p, 2), NumberStyles.HexNumber);
							numArray[p / 2] = num7;
						}
						Guid dQWord = GuidExt.GetGuidFromDoubleULong(BitConverter.ToUInt64(numArray, 0), BitConverter.ToUInt64(numArray, 8));
						if (!PlotFlagTable.ContainsKey(dQWord))
						{
							PlotFlagTable.Add(dQWord, strArrays2[2]);
						}
					}
				}
			}
		}

		public static void Serialize(BinaryWriter writer)
		{
			LibrarySerializer.Serialize(writer);
		}

		public static void Deserialize(BinaryReader reader)
		{
			InitLibrary();
			DateTime startDate = DateTime.Now;
			LibrarySerializer.Deserialize(reader);
			(DateTime.Now - startDate).ToDebugWindow("deserialize cache");
			WriteEbxNameTypes();
			LoadTalktables(ResNameLookup.Values.Where((ResRef x) => x.ResType == 1585851909).ToList());
		}

		public static EbxRef GetEbxByGuid(Guid fileGuid)
		{
			if (!EbxGuidLookup.ContainsKey(fileGuid))
			{
				return null;
			}
			return EbxGuidLookup[fileGuid];
		}

		public static EbxRef GetEbxByNameHash(string nameHash)
		{
			if (EbxNameSha1Lookup.ContainsKey(nameHash))
			{
				return EbxNameSha1Lookup[nameHash];
			}
			return null;
		}

		public static List<EbxRef> GetAllEbx()
		{
			return AllEbx.Values.ToList();
		}

		internal static void RemoveEbx(EbxRef ebx)
		{
			EbxGuidLookup.Remove(ebx.FileGuid);
			AllEbx.Remove(ebx.Name);
		}

		internal static void AddEbx(EbxRef ebx)
		{
			if (!AllEbx.ContainsKey(ebx.Name))
			{
				AllEbx.Add(ebx.Name, ebx);
				if (!EbxGuidLookup.ContainsKey(ebx.FileGuid))
				{
					EbxGuidLookup.Add(ebx.FileGuid, ebx);
				}
				string nameHash = ebx.Name.ToSha1();
				if (!EbxNameSha1Lookup.ContainsKey(nameHash))
				{
					EbxNameSha1Lookup.Add(nameHash, ebx);
				}
			}
		}

		internal static void RemoveFromBundles(EbxRef ebx, List<SubBundleRef> bundles = null)
		{
			if (bundles == null)
			{
				bundles = GetAllSubBundles();
			}
			foreach (SubBundleRef bundle in bundles)
			{
				bundle.Ebx.Remove(ebx);
			}
		}

		public static List<ResRef> GetAllRes()
		{
			return AllRes.Values.ToList();
		}

		public static ResRef GetResByResRid(long resRid)
		{
			if (!AllRes.ContainsKey(resRid))
			{
				return null;
			}
			return AllRes[resRid];
		}

		public static ResRef GetResByName(string name)
		{
			if (ResNameLookup.ContainsKey(name.ToLower()))
			{
				return ResNameLookup[name.ToLower()];
			}
			return null;
		}

		internal static void AddRes(ResRef res)
		{
			if (!AllRes.ContainsKey(res.ResRid) && res.ResRid != 0L)
			{
				AllRes.Add(res.ResRid, res);
				if (!ResNameLookup.ContainsKey(res.Name.ToLower()))
				{
					ResNameLookup.Add(res.Name.ToLower(), res);
				}
			}
		}

		internal static void RemoveRes(ResRef res)
		{
			AllRes.Remove(res.ResRid);
			ResNameLookup.Remove(res.Name.ToLower());
		}

		public static ChunkRef GetChunkById(Guid id)
		{
			if (!AllChunks.ContainsKey(id))
			{
				return null;
			}
			return AllChunks[id];
		}

		public static List<ChunkRef> GetAllChunks()
		{
			return AllChunks.Values.ToList();
		}

		internal static void AddChunk(ChunkRef c)
		{
			if (!AllChunks.ContainsKey(c.ChunkId))
			{
				AllChunks.Add(c.ChunkId, c);
			}
		}

		internal static void RemoveChunk(ChunkRef c)
		{
			AllChunks.Remove(c.ChunkId);
			SubBundleRef[] array = c.ParentSbs.ToArray();
			foreach (SubBundleRef sb in array)
			{
				sb.Chunks.Remove(c);
				c.ParentSbs.Remove(sb);
			}
		}

		internal static SubBundleRef AddSubBundle(SubBundleRef sb)
		{
			if (AllSubBundles.ContainsKey(sb.Path))
			{
				return AllSubBundles[sb.Path];
			}
			AllSubBundles.Add(sb.Path, sb);
			return sb;
		}

		public static SubBundleRef GetSubBundle(string path)
		{
			if (AllSubBundles.ContainsKey(path))
			{
				return AllSubBundles[path];
			}
			return null;
		}

		public static string GetPlotFlag(Guid InGuid)
		{
			if (InGuid == Guid.Empty)
			{
				return InGuid.ToString();
			}
			if (!PlotFlagTable.ContainsKey(InGuid))
			{
				return InGuid.ToString();
			}
			return PlotFlagTable[InGuid];
		}

		public static Talktable.TalktableString GetString(string InLangID, uint InIndex)
		{
			if (InIndex == 0)
			{
				return null;
			}
			if (!StringTable.ContainsKey(InLangID))
			{
				return null;
			}
			if (!StringTable[InLangID].ContainsKey(InIndex))
			{
				return null;
			}
			return StringTable[InLangID][InIndex];
		}

		public static string GetStringValue(string InLangID, uint InIndex)
		{
			if (InIndex == 0)
			{
				return null;
			}
			if (!StringTable.ContainsKey(InLangID))
			{
				return null;
			}
			if (!StringTable[InLangID].ContainsKey(InIndex))
			{
				return null;
			}
			return StringTable[InLangID][InIndex].Value;
		}

		public static List<Talktable.TalktableString> GetAllStrings(string InLangID)
		{
			return StringTable[InLangID].Values.ToList();
		}

		internal static void AddString(string LangID, Talktable.TalktableString InString)
		{
			if (!StringTable.ContainsKey(LangID))
			{
				StringTable.Add(LangID, new Dictionary<uint, Talktable.TalktableString>());
			}
			if (!StringTable[LangID].ContainsKey(InString.ID))
			{
				StringTable[LangID].Add(InString.ID, InString);
			}
		}

		public static List<string> GetAllLanguages()
		{
			return StringTable.Keys.ToList();
		}

		public static string GetEvent(int InHash)
		{
			if (InHash == 0)
			{
				return InHash.ToString("X8");
			}
			if (!EventTable.ContainsKey(InHash))
			{
				return InHash.ToString("X8");
			}
			return EventTable[InHash];
		}

		public static List<SubBundleRef> GetAllSubBundles()
		{
			return AllSubBundles.Values.ToList();
		}

		internal static void AddToBundle(EbxRef ebx, SubBundleRef sb)
		{
			if (!ebx.ParentSbs.Contains(sb))
			{
				ebx.ParentSbs.Add(sb);
			}
			if (!sb.Ebx.Contains(ebx))
			{
				sb.Ebx.Add(ebx);
			}
		}

		internal static void AddToBundle(ResRef res, SubBundleRef sb)
		{
			if (!res.ParentSbs.Contains(sb))
			{
				res.ParentSbs.Add(sb);
			}
			if (!sb.Res.Contains(res))
			{
				sb.Res.Add(res);
			}
		}

		internal static void AddToBundle(ChunkRef c, SubBundleRef sb)
		{
			if (!sb.Chunks.Contains(c))
			{
				sb.Chunks.Add(c);
			}
			if (!c.ParentSbs.Contains(sb))
			{
				c.ParentSbs.Add(sb);
			}
		}

		public static void RemoveFromBundle(SubBundleRef sb, ResRef res)
		{
			sb.Res.Remove(res);
			res.ParentSbs.Remove(sb);
		}

		public static void RemoveFromBundle(SubBundleRef sb, EbxRef ebx)
		{
			sb.Ebx.Remove(ebx);
			ebx.ParentSbs.Remove(sb);
		}

		public static void RemoveFromBundle(SubBundleRef sb, ChunkRef chunk)
		{
			sb.Chunks.Remove(chunk);
			chunk.ParentSbs.Remove(sb);
		}

		public static List<string> GetEbxTypes()
		{
			List<string> names = new List<string>();
			GetAllEbx().ForEach(delegate(EbxRef ebx)
			{
				names.Add(ebx.AssetType);
			});
			names = names.Distinct().ToList();
			names.Sort();
			return names;
		}
	}
}

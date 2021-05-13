using System.Collections.Generic;
using System.Linq;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;

namespace DAI.AssetLibrary.Utilities
{
	public static class LibraryManager
	{
		public static void AddCatalogEntry(CatalogEntry catEntry)
		{
			catEntry.IsNew = true;
			Library.CasEntries.Add(catEntry.Sha1, catEntry);
		}

		public static void ClearModifiedData()
		{
			foreach (CatalogEntry modCat in Library.CasEntries.Values.Where((CatalogEntry x) => x.IsNew).ToList())
			{
				Library.CasEntries.Remove(modCat.Sha1);
			}
			foreach (KeyValuePair<string, Dictionary<uint, Talktable.TalktableString>> pair in Library.StringTable)
			{
				foreach (Talktable.TalktableString tString in pair.Value.Values.Where((Talktable.TalktableString x) => x.State != Talktable.TalktableStringState.NoChanges))
				{
					if (tString.State == Talktable.TalktableStringState.Added)
					{
						Library.StringTable[pair.Key].Remove(tString.ID);
						continue;
					}
					tString.State = Talktable.TalktableStringState.NoChanges;
					tString.Value = tString.OriginalValue;
				}
			}
			foreach (AssetEntryRef entry in Library.ModifiedEntries)
			{
				switch (entry.State)
				{
				case EntryState.Added:
					if (entry.GetType() == typeof(EbxRef))
					{
						Library.RemoveEbx((EbxRef)entry);
					}
					else if (entry.GetType() == typeof(ResRef))
					{
						Library.RemoveRes((ResRef)entry);
					}
					else if (entry.GetType() == typeof(ChunkRef))
					{
						Library.RemoveChunk((ChunkRef)entry);
					}
					break;
				case EntryState.Modified:
				case EntryState.Deleted:
				{
					entry.ModifiedData = null;
					entry.State = EntryState.NoChanges;
					SubBundleRef[] array = entry.RemovedSbs.ToArray();
					foreach (SubBundleRef sb2 in array)
					{
						if (entry.GetType() == typeof(EbxRef))
						{
							Library.AddToBundle((EbxRef)entry, sb2);
						}
						else if (entry.GetType() == typeof(ResRef))
						{
							Library.AddToBundle((ResRef)entry, sb2);
						}
						else if (entry.GetType() == typeof(ChunkRef))
						{
							Library.AddToBundle((ChunkRef)entry, sb2);
						}
					}
					entry.RemovedSbs.Clear();
					break;
				}
				}
				entry.ParentSbs.RemoveAll((SubBundleRef x) => entry.AddedSbs.Contains(x));
				entry.AddedSbs.Clear();
			}
			Library.ModifiedEntries.Clear();
			foreach (SubBundleRef sb in Library.AllSubBundles.Values.Where((SubBundleRef x) => x.State != EntryState.NoChanges).ToList())
			{
				if (sb.State == EntryState.Added)
				{
					Library.AllSubBundles.Remove(sb.Path);
				}
				else
				{
					sb.State = EntryState.NoChanges;
				}
			}
		}

		public static void AddNewSubBundle(SubBundleRef sb)
		{
			sb.State = EntryState.Added;
			Library.AddSubBundle(sb);
			sb.Ebx.Clear();
			sb.Res.Clear();
			sb.Chunks.Clear();
		}

		public static void AddEbx(EbxRef ebx, byte[] modifiedData, bool compressed)
		{
			Library.AddEbx(ebx);
			AddEntry(ebx);
			ModifyEbx(ebx, modifiedData, compressed);
		}

		public static void AddChunk(ChunkRef c, byte[] modifiedData, bool isCompressed)
		{
			c.State = EntryState.Added;
			ModifyChunk(c, modifiedData, isCompressed);
			Library.AllChunks.Add(c.ChunkId, c);
		}

		public static void AddRes(ResRef res, byte[] modifiedData, bool isCompressed)
		{
			Library.AddRes(res);
			AddEntry(res);
			ModifyRes(res, modifiedData, isCompressed);
		}

		public static void ModifyEbx(EbxRef ebx, byte[] data, bool compressed)
		{
			ModifyEntry(ebx, data, compressed);
			foreach (SubBundleRef item in ebx.ParentSbs.Where((SubBundleRef x) => x.State == EntryState.NoChanges))
			{
				item.State = EntryState.Modified;
			}
		}

		public static void ModifyRes(ResRef res, byte[] data, bool compressed)
		{
			ModifyEntry(res, data, compressed);
			foreach (SubBundleRef item in res.ParentSbs.Where((SubBundleRef x) => x.State == EntryState.NoChanges))
			{
				item.State = EntryState.Modified;
			}
		}

		private static void ModifyChunk(ChunkRef chunk, byte[] data, bool compressed)
		{
			ModifyEntry(chunk, data, compressed);
			foreach (SubBundleRef item in chunk.ParentSbs.Where((SubBundleRef x) => x.State == EntryState.NoChanges))
			{
				item.State = EntryState.Modified;
			}
		}

		public static void DeleteEbx(EbxRef ebx)
		{
			DeleteEntry(ebx);
			SubBundleRef[] array = ebx.AddedSbs.ToArray();
			foreach (SubBundleRef sb in array)
			{
				RemoveFromBundle(ebx, sb);
			}
			array = ebx.ParentSbs.ToArray();
			foreach (SubBundleRef sb2 in array)
			{
				RemoveFromBundle(ebx, sb2);
			}
		}

		public static void DeleteRes(ResRef res)
		{
			DeleteEntry(res);
			SubBundleRef[] array = res.AddedSbs.ToArray();
			foreach (SubBundleRef sb in array)
			{
				RemoveFromBundle(res, sb);
			}
			array = res.ParentSbs.ToArray();
			foreach (SubBundleRef sb2 in array)
			{
				RemoveFromBundle(res, sb2);
			}
		}

		public static void DeleteChunk(ChunkRef c)
		{
			DeleteEntry(c);
			SubBundleRef[] array = c.AddedSbs.ToArray();
			foreach (SubBundleRef sb in array)
			{
				RemoveFromBundle(c, sb);
			}
			array = c.ParentSbs.ToArray();
			foreach (SubBundleRef sb2 in array)
			{
				RemoveFromBundle(c, sb2);
			}
		}

		public static bool ModifyString(string InLangID, uint InIndex, string InValue)
		{
			if (!Library.StringTable.ContainsKey(InLangID))
			{
				return false;
			}
			if (!Library.StringTable[InLangID].ContainsKey(InIndex))
			{
				return false;
			}
			ModifyString(Library.StringTable[InLangID][InIndex], InValue);
			return true;
		}

		public static void ModifyString(Talktable.TalktableString str, string InValue)
		{
			if (str.State == Talktable.TalktableStringState.NoChanges)
			{
				str.State = Talktable.TalktableStringState.Modified;
				str.OriginalValue = str.Value;
			}
			str.Value = InValue;
		}

		public static void AddString(string LangID, uint id, string InString)
		{
			if (!Library.StringTable.ContainsKey(LangID))
			{
				Library.StringTable.Add(LangID, new Dictionary<uint, Talktable.TalktableString>());
			}
			if (!Library.StringTable[LangID].ContainsKey(id))
			{
				Talktable.TalktableString str = new Talktable.TalktableString();
				str.ID = id;
				str.Value = InString;
				Library.StringTable[LangID].Add(id, str);
				str.State = Talktable.TalktableStringState.Added;
			}
		}

		public static void AddToBundle(EbxRef ebx, SubBundleRef sb)
		{
			if (!ebx.ParentSbs.Contains(sb))
			{
				ebx.ParentSbs.Add(sb);
				ebx.AddedSbs.Add(sb);
			}
			if (!sb.Ebx.Contains(ebx))
			{
				sb.Ebx.Add(ebx);
			}
		}

		public static void AddToBundle(ResRef res, SubBundleRef sb)
		{
			if (!res.ParentSbs.Contains(sb))
			{
				res.ParentSbs.Add(sb);
				res.AddedSbs.Add(sb);
			}
			if (!sb.Res.Contains(res))
			{
				sb.Res.Add(res);
			}
		}

		public static void AddToBundle(ChunkRef c, SubBundleRef sb)
		{
			if (!sb.Chunks.Contains(c))
			{
				sb.Chunks.Add(c);
			}
			if (!c.ParentSbs.Contains(sb))
			{
				c.ParentSbs.Add(sb);
				c.AddedSbs.Add(sb);
			}
		}

		public static void AddToBundles(ChunkRef c, IEnumerable<SubBundleRef> sbs)
		{
			foreach (SubBundleRef sb in sbs)
			{
				AddToBundle(c, sb);
			}
		}

		public static void RemoveFromBundle(EbxRef ebx, SubBundleRef sb)
		{
			if (!ebx.RemovedSbs.Contains(sb) && ebx.ParentSbs.Contains(sb))
			{
				ebx.RemovedSbs.Add(sb);
				ebx.ParentSbs.Remove(sb);
				ebx.AddedSbs.Remove(sb);
				sb.Ebx.Remove(ebx);
			}
		}

		public static void RemoveFromBundle(ResRef res, SubBundleRef sb)
		{
			if (!res.RemovedSbs.Contains(sb) && res.ParentSbs.Contains(sb))
			{
				res.RemovedSbs.Add(sb);
				res.ParentSbs.Remove(sb);
				res.AddedSbs.Remove(sb);
				sb.Res.Remove(res);
			}
		}

		public static void RemoveFromBundle(ChunkRef chunk, SubBundleRef sb)
		{
			if (!chunk.RemovedSbs.Contains(sb) && chunk.ParentSbs.Contains(sb))
			{
				chunk.RemovedSbs.Add(sb);
				chunk.ParentSbs.Remove(sb);
				chunk.AddedSbs.Remove(sb);
				sb.Chunks.Remove(chunk);
			}
		}

		internal static void DeleteEntry(AssetEntryRef entry)
		{
			if (entry.State != EntryState.Added)
			{
				entry.State = EntryState.Deleted;
				if (!Library.ModifiedEntries.Contains(entry))
				{
					Library.ModifiedEntries.Add(entry);
				}
			}
			else
			{
				Library.ModifiedEntries.Remove(entry);
			}
		}

		internal static void ModifyEntry(AssetEntryRef entry, byte[] data, bool compressed)
		{
			if (entry.State != EntryState.Added)
			{
				entry.State = EntryState.Modified;
			}
			entry.ModifiedData = (compressed ? data : Utilities.CompressData(data));
			entry.DataOriginalSize = data.Length;
			if (!Library.ModifiedEntries.Contains(entry))
			{
				Library.ModifiedEntries.Add(entry);
			}
		}

		internal static void AddEntry(AssetEntryRef entry)
		{
			entry.State = EntryState.Added;
			if (!Library.ModifiedEntries.Contains(entry))
			{
				Library.ModifiedEntries.Add(entry);
			}
		}
	}
}

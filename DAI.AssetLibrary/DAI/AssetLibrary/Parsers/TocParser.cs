using System.Collections.Generic;
using System.IO;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;

namespace DAI.AssetLibrary.Parsers
{
	public static class TocParser
	{
		public static TableOfContentRef ParseToc(string filename, string basePath, FolderType ft, bool includeSBs = true)
		{
			TableOfContentRef toc = new TableOfContentRef();
			toc.EntryPath = filename.Replace(basePath + "\\", "");
			using (MemoryStream ms = new MemoryStream(DAI.AssetLibrary.Utilities.Utilities.DecodeFile(filename)))
			{
				using (BinaryReader reader = new BinaryReader(ms))
				{
					if (!reader.ParseEntry(toc))
					{
						return null;
					}
				}
			}
			if (includeSBs && toc.Bundles != null && toc.Bundles.Count > 0)
			{
				foreach (BundleRef b in toc.Bundles)
				{
					if (b == null)
					{
						continue;
					}
					string sbFilename = filename.Replace(".toc", ".sb");
					if (File.Exists(sbFilename) && !b.Base)
					{
						SubBundleRef sb = null;
						sb = ((!toc.Cas) ? SBParser.ParseBinarySubBundle(sbFilename, basePath, b.Offset) : SBParser.ParseSubBundle(sbFilename, basePath, b.Offset));
						if (sb != null)
						{
							toc.SubBundles.Add(sb);
							sb.Base = b.Base;
							sb.Delta = b.Delta;
						}
					}
				}
			}
			toc.Bundles.Clear();
			return toc;
		}

		internal static List<TableOfContentRef> ParseTocFolder(string basePath, string folder, FolderType ft, bool includeSBs)
		{
			List<TableOfContentRef> tocs = new List<TableOfContentRef>();
			string[] files = Directory.GetFiles(Path.Combine(Path.Combine(basePath, folder), "Win32"), "*.toc", SearchOption.AllDirectories);
			for (int i = 0; i < files.Length; i++)
			{
				TableOfContentRef toc = ParseToc(files[i], basePath, ft, includeSBs);
				tocs.Add(toc);
			}
			return tocs;
		}
	}
}

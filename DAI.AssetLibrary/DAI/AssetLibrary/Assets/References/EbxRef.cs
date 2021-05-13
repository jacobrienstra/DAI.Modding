using System;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary.Assets.References
{
	public class EbxRef : AssetEntryRef
	{
		public string Name { get; set; }

		public string Sha1 { get; set; }

		public long Size { get; set; }

		public long OriginalSize { get; set; }

		public int CasPatchType { get; set; }

		public string BaseSha1 { get; set; }

		public string DeltaSha1 { get; set; }

		public string AssetType { get; set; }

		public Guid FileGuid { get; set; }

		public uint NameHash => (uint)Name.Hash();

		public EbxRef()
		{
			Name = string.Empty;
			Sha1 = string.Empty;
			AssetType = string.Empty;
			CasPatchType = 0;
			BaseSha1 = string.Empty;
			DeltaSha1 = string.Empty;
		}
	}
}

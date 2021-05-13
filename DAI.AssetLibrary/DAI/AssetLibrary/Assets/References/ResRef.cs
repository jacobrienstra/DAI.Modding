namespace DAI.AssetLibrary.Assets.References
{
	public class ResRef : AssetEntryRef
	{
		public string Name { get; set; }

		public string Sha1 { get; set; }

		public long Size { get; set; }

		public long OriginalSize { get; set; }

		public int ResType { get; set; }

		public byte[] ResMeta { get; set; }

		public long ResRid { get; set; }

		public int CasPatchType { get; set; }

		public string BaseSha1 { get; set; }

		public string DeltaSha1 { get; set; }

		public ResRef()
		{
			Name = string.Empty;
			Sha1 = string.Empty;
			BaseSha1 = string.Empty;
			DeltaSha1 = string.Empty;
			CasPatchType = 0;
		}
	}
}

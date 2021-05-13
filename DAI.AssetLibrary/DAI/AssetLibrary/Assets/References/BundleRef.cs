namespace DAI.AssetLibrary.Assets.References
{
	public class BundleRef : EntryRef
	{
		public string Id { get; set; }

		public long Offset { get; set; }

		public long Size { get; set; }

		public bool Base { get; set; }

		public bool Delta { get; set; }

		public BundleRef()
		{
			Base = false;
			Delta = false;
		}
	}
}

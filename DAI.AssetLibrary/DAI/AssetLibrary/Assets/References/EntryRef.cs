namespace DAI.AssetLibrary.Assets.References
{
	public class EntryRef
	{
		public string EntryPath { get; set; }

		public int EntryOffset { get; set; }

		public string BinaryName { get; set; }

		public bool FromDLC { get; set; }

		public EntryRef()
		{
			BinaryName = string.Empty;
			FromDLC = false;
		}
	}
}

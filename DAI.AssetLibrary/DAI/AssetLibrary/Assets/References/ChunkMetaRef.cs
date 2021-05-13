namespace DAI.AssetLibrary.Assets.References
{
	public class ChunkMetaRef : EntryRef
	{
		public int H32 { get; set; }

		public byte[] Meta { get; set; }

		public ChunkMetaRef()
		{
		}

		public ChunkMetaRef(int h32, byte[] meta)
		{
			H32 = h32;
			Meta = meta;
		}
	}
}

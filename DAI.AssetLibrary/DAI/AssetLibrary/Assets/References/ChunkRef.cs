using System;

namespace DAI.AssetLibrary.Assets.References
{
	public class ChunkRef : AssetEntryRef
	{
		internal string Id { get; set; }

		public string Sha1 { get; set; }

		public int Size { get; set; }

		public int LogicalOffset { get; set; }

		public int LogicalSize { get; set; }

		public long? Offset { get; set; }

		public int? RangeStart { get; set; }

		public int? RangeEnd { get; set; }

		public int CasPatchType { get; set; }

		public Guid ChunkId { get; set; }

		public int? H32 { get; set; }

		public byte[] Meta { get; set; }

		public ChunkRef()
		{
			ChunkId = Guid.Empty;
			Sha1 = string.Empty;
			Meta = null;
			CasPatchType = 7;
		}
	}
}

using System.Collections.Generic;

namespace DAI.AssetLibrary.Assets.References
{
	public class ChunkIdComparer : IEqualityComparer<ChunkRef>
	{
		public bool Equals(ChunkRef x, ChunkRef y)
		{
			return x.ChunkId == y.ChunkId;
		}

		public int GetHashCode(ChunkRef obj)
		{
			return obj.ChunkId.GetHashCode();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SocketAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<SocketInfo> Sockets { get; set; }

		[FieldOffset(16, 80)]
		public List<short> ServerSocketIndices { get; set; }

		public SocketAsset()
		{
			Sockets = new List<SocketInfo>();
			ServerSocketIndices = new List<short>();
		}
	}
}

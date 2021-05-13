using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RawFileDataAsset : RawFileAsset
	{
		[FieldOffset(12, 80)]
		public List<byte> RawData { get; set; }

		[FieldOffset(16, 88)]
		public uint Size { get; set; }

		public RawFileDataAsset()
		{
			RawData = new List<byte>();
		}
	}
}

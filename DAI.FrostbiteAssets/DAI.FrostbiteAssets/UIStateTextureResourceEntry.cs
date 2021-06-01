using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIStateTextureResourceEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint Hash { get; set; }

		[FieldOffset(4, 8)]
		public List<uint> AltHashes { get; set; }

		public UIStateTextureResourceEntry()
		{
			AltHashes = new List<uint>();
		}
	}
}

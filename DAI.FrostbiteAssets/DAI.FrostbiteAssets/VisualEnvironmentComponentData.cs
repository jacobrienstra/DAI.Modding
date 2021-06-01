using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class VisualEnvironmentComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public List<string> PropertyOverrides { get; set; }

		[FieldOffset(100, 184)]
		public List<uint> PropertyOverrideMasks { get; set; }

		public VisualEnvironmentComponentData()
		{
			PropertyOverrides = new List<string>();
			PropertyOverrideMasks = new List<uint>();
		}
	}
}

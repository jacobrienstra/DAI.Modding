using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BlueprintBundleReference : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Name { get; set; }

		[FieldOffset(4, 8)]
		public BlueprintBundleSettings Settings { get; set; }

		[FieldOffset(24, 80)]
		public List<SharedBundleReference> Parents { get; set; }

		public BlueprintBundleReference()
		{
			Parents = new List<SharedBundleReference>();
		}
	}
}

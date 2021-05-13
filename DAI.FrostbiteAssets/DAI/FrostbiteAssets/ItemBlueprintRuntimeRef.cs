using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemBlueprintRuntimeRef : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint DelayLoadBundleHash { get; set; }

		[FieldOffset(4, 8)]
		public MaterialDecl Material { get; set; }

		[FieldOffset(8, 24)]
		public ExternalObject<SoundPatchConfigurationAsset> Sound { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<Dummy> BodyFallSound { get; set; }

		[FieldOffset(16, 40)]
		public List<BWTimelineReference> OnDisplayTimelines { get; set; }

		public ItemBlueprintRuntimeRef()
		{
			OnDisplayTimelines = new List<BWTimelineReference>();
		}
	}
}

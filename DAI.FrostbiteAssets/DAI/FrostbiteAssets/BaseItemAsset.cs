using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BaseItemAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public uint NameHash { get; set; }

		[FieldOffset(16, 80)]
		public LocalizedStringReference DisplayName { get; set; }

		[FieldOffset(20, 104)]
		public LocalizedStringReference Description { get; set; }

		[FieldOffset(24, 128)]
		public ItemDefaultCost DefaultCost { get; set; }

		[FieldOffset(40, 152)]
		public int CostModifier { get; set; }

		[FieldOffset(44, 156)]
		public int CostOverride { get; set; }

		[FieldOffset(48, 160)]
		public List<ExternalObject<PlotEvent>> PlotEvents { get; set; }

		[FieldOffset(52, 168)]
		public UITextureAtlasTextureReference AtlasedIcon { get; set; }

		[FieldOffset(72, 208)]
		public ExternalObject<SoundActionList> SoundActions { get; set; }

		[FieldOffset(76, 216)]
		public bool PreventSellDestroy { get; set; }

		public BaseItemAsset()
		{
			PlotEvents = new List<ExternalObject<PlotEvent>>();
		}
	}
}

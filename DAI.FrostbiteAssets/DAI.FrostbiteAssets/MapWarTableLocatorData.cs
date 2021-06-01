using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class MapWarTableLocatorData : BaseWarTableLocatorData
	{
		[FieldOffset(80, 176)]
		public WarTableMapChoiceId WarTableMapChoiceId { get; set; }

		[FieldOffset(84, 184)]
		public LocalizedStringReference MapName { get; set; }

		[FieldOffset(88, 208)]
		public LocalizedStringReference MapDescription { get; set; }

		[FieldOffset(92, 232)]
		public string MapImageName { get; set; }
	}
}

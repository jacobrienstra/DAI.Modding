using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PromptCharacterSoundsetFilterData : SoundsetFilterData
	{
		[FieldOffset(12, 32)]
		public PromptTarget Target { get; set; }
	}
}

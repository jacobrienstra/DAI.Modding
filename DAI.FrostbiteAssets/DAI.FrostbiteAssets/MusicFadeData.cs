using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicFadeData : DataContainer
	{
		[FieldOffset(8, 24)]
		public float FadeOutLength { get; set; }

		[FieldOffset(12, 28)]
		public MusicFadeType FadeOutType { get; set; }

		[FieldOffset(16, 32)]
		public float FadeInLength { get; set; }

		[FieldOffset(20, 36)]
		public MusicFadeType FadeInType { get; set; }

		[FieldOffset(24, 40)]
		public bool EqualPower { get; set; }
	}
}

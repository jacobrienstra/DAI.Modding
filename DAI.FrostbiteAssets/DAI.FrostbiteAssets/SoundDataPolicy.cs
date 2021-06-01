using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundDataPolicy : DataContainer
	{
		[FieldOffset(8, 24)]
		public string Name { get; set; }

		[FieldOffset(12, 32)]
		public SoundDataRequestBehavior RequestBehavior { get; set; }

		[FieldOffset(16, 36)]
		public SoundDataReleaseBehavior ReleaseBehavior { get; set; }

		[FieldOffset(20, 40)]
		public SoundDataReadTarget PrimeTarget { get; set; }

		[FieldOffset(24, 44)]
		public SoundDataReadTarget RequestTarget { get; set; }
	}
}

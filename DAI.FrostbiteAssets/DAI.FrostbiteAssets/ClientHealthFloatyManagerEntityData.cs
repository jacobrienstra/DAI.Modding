namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ClientHealthFloatyManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public float DurationSec { get; set; }

		[FieldOffset(20, 100)]
		public float FadeInSec { get; set; }

		[FieldOffset(24, 104)]
		public float FadeOutSec { get; set; }

		[FieldOffset(28, 108)]
		public float CutoffDistance { get; set; }
	}
}

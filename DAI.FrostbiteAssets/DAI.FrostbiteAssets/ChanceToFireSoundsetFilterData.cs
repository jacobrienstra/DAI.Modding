namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ChanceToFireSoundsetFilterData : SoundsetFilterData
	{
		[FieldOffset(12, 32)]
		public int ChanceToFire { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GlobalCooldownSoundsetFilterData : SoundsetFilterData
	{
		[FieldOffset(12, 32)]
		public float Cooldown { get; set; }
	}
}

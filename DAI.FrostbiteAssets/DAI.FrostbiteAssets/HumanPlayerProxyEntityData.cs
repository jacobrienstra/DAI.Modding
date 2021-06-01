namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class HumanPlayerProxyEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public bool EnableOnDiedOnMeleeEvent { get; set; }

		[FieldOffset(17, 97)]
		public bool EnableOnDiedInWaterEvent { get; set; }
	}
}

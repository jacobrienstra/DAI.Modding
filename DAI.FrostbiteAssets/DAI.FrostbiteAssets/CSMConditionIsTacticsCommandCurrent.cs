namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionIsTacticsCommandCurrent : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider_Self> Entity { get; set; }

		[FieldOffset(12, 40)]
		public bool CheckAbility { get; set; }

		[FieldOffset(13, 41)]
		public bool CheckPartner { get; set; }
	}
}

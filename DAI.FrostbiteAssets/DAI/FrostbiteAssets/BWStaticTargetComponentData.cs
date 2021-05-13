namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWStaticTargetComponentData : BWTargetComponentData
	{
		[FieldOffset(112, 208)]
		public bool CombatTargetable { get; set; }

		[FieldOffset(113, 209)]
		public bool FindableOnServer { get; set; }
	}
}

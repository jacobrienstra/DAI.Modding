namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ApplyVariation : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public string VariationName { get; set; }

		[FieldOffset(32, 80)]
		public bool ResetAtEnd { get; set; }

		[FieldOffset(33, 81)]
		public bool ClearTransientEffects { get; set; }
	}
}

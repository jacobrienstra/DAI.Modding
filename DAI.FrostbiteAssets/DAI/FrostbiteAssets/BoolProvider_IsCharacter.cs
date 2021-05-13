namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_IsCharacter : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TacticsTargetEntityProvider> Entity { get; set; }

		[FieldOffset(12, 40)]
		public bool ReturnIfInvalid { get; set; }
	}
}

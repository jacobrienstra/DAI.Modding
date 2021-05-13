namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionBoolGameState : BWConditional
	{
		[FieldOffset(8, 32)]
		public AntRef GameStateBool { get; set; }

		[FieldOffset(28, 80)]
		public bool Value { get; set; }
	}
}

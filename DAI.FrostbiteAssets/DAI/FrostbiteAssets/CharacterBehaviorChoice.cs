namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterBehaviorChoice : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint ChoiceID { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference ChoiceName { get; set; }

		[FieldOffset(8, 32)]
		public ExternalObject<BTEvalFunc> Condition { get; set; }
	}
}

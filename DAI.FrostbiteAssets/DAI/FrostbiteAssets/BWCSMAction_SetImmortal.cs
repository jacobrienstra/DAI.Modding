namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetImmortal : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<EntityProvider_Self> Entity { get; set; }

		[FieldOffset(32, 80)]
		public bool Value { get; set; }

		[FieldOffset(33, 81)]
		public bool FakeImmortal { get; set; }

		[FieldOffset(34, 82)]
		public bool ResetAtEnd { get; set; }
	}
}

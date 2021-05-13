namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetGameStateBool : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public AntRef GameStateBool { get; set; }

		[FieldOffset(48, 120)]
		public ExternalObject<BoolProvider> BoolProviderStart { get; set; }

		[FieldOffset(52, 128)]
		public ExternalObject<BoolProvider> BoolProviderEnd { get; set; }

		[FieldOffset(56, 136)]
		public ExternalObject<Dummy> Entity { get; set; }

		[FieldOffset(60, 144)]
		public int Animatable { get; set; }

		[FieldOffset(64, 148)]
		public bool Value { get; set; }

		[FieldOffset(65, 149)]
		public bool ResetOnEnd { get; set; }
	}
}

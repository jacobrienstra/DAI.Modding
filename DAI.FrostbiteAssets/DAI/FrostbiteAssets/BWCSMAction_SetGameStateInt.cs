namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetGameStateInt : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public AntRef GameStateInt { get; set; }

		[FieldOffset(48, 120)]
		public ExternalObject<IntegerProvider_Const> Value { get; set; }

		[FieldOffset(52, 128)]
		public ExternalObject<Dummy> EndValue { get; set; }

		[FieldOffset(56, 136)]
		public ExternalObject<Dummy> Entity { get; set; }

		[FieldOffset(60, 144)]
		public int Animatable { get; set; }
	}
}

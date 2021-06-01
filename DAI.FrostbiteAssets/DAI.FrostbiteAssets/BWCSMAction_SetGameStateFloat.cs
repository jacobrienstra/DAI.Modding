namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetGameStateFloat : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public AntRef GameStateFloat { get; set; }

		[FieldOffset(48, 120)]
		public ExternalObject<FloatProvider> Value { get; set; }

		[FieldOffset(52, 128)]
		public ExternalObject<FloatProvider> FloatProviderEnd { get; set; }

		[FieldOffset(56, 136)]
		public ExternalObject<EntityProvider_Self> Entity { get; set; }

		[FieldOffset(60, 144)]
		public int Animatable { get; set; }

		[FieldOffset(64, 148)]
		public bool Blend { get; set; }

		[FieldOffset(65, 149)]
		public bool Continuous { get; set; }
	}
}

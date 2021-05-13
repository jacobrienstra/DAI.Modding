namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetGameStateTransform : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public AntRef GameStateVector { get; set; }

		[FieldOffset(48, 120)]
		public ExternalObject<TransformProvider> Transform { get; set; }
	}
}

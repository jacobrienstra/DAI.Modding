namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetGameStateEnum : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<AntEnumeration> Enum { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<EntityProvider_Self> Entity { get; set; }

		[FieldOffset(36, 88)]
		public int Animatable { get; set; }
	}
}

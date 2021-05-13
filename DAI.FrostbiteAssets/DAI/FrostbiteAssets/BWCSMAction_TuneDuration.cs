namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_TuneDuration : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<FloatProvider> TunedDuration { get; set; }

		[FieldOffset(32, 80)]
		public float EaseIn { get; set; }

		[FieldOffset(36, 84)]
		public float EaseOut { get; set; }
	}
}

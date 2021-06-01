namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_PlaySoundBase : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public int FilterId { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<TransformProvider> Transform { get; set; }

		[FieldOffset(36, 88)]
		public int AttachToId { get; set; }

		[FieldOffset(40, 92)]
		public bool AttachToTimelineTransform { get; set; }

		[FieldOffset(41, 93)]
		public bool StayAttached { get; set; }

		[FieldOffset(42, 94)]
		public bool FireDefaultStartEvent { get; set; }

		[FieldOffset(43, 95)]
		public bool FireDefaultStopEvent { get; set; }
	}
}

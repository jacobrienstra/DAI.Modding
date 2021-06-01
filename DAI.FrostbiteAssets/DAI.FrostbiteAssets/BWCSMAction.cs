namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction : BWCSMTimelineEvent
	{
		[FieldOffset(24, 64)]
		public bool AllowLateStart { get; set; }

		[FieldOffset(25, 65)]
		public bool LateStartNoTimeOffset { get; set; }

		[FieldOffset(26, 66)]
		public bool DeactivateWithConditional { get; set; }

		[FieldOffset(27, 67)]
		public bool SuppressClientServerDeSyncWarning { get; set; }
	}
}

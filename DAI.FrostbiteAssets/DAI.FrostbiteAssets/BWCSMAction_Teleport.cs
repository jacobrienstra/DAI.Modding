namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_Teleport : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<TransformProvider> Location { get; set; }

		[FieldOffset(32, 80)]
		public float DistanceToTarget { get; set; }

		[FieldOffset(36, 84)]
		public float AngleToSearch { get; set; }

		[FieldOffset(40, 88)]
		public float AngleStep { get; set; }

		[FieldOffset(44, 92)]
		public bool ClearMovementCommands { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_TranslateToTarget : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<TransformProvider> Target { get; set; }

		[FieldOffset(32, 80)]
		public float MaxSpeed { get; set; }

		[FieldOffset(36, 84)]
		public bool ApplyVertical { get; set; }

		[FieldOffset(37, 85)]
		public bool ContinuousUpdate { get; set; }
	}
}

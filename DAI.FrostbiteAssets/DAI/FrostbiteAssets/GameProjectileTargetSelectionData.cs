namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameProjectileTargetSelectionData : DataContainer
	{
		[FieldOffset(8, 24)]
		public float HomingFieldOfView { get; set; }

		[FieldOffset(12, 28)]
		public float PromiscuousHomingSearchRadius { get; set; }

		[FieldOffset(16, 32)]
		public int PromiscuousHomingFramesPerQuery { get; set; }

		[FieldOffset(20, 40)]
		public ExternalObject<TransformProvider> TargetTransform { get; set; }

		[FieldOffset(24, 48)]
		public bool EnablePromiscuousHoming { get; set; }

		[FieldOffset(25, 49)]
		public bool SwitchHomingTargets { get; set; }
	}
}

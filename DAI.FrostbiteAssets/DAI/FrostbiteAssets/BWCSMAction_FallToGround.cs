namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_FallToGround : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public int StoredTransformSlot { get; set; }

		[FieldOffset(32, 80)]
		public Vec3 FallingHorizontalDistanceTravelled { get; set; }

		[FieldOffset(48, 96)]
		public ExternalObject<TransformProvider_Socket> FromTransform { get; set; }

		[FieldOffset(52, 104)]
		public bool ContinuousUpdate { get; set; }

		[FieldOffset(53, 105)]
		public bool Physics { get; set; }

		[FieldOffset(54, 106)]
		public bool ScaleStateTime { get; set; }
	}
}

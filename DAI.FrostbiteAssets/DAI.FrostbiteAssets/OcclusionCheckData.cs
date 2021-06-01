namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class OcclusionCheckData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform TargetPosition { get; set; }

		[FieldOffset(80, 160)]
		public float MaxDistance { get; set; }
	}
}

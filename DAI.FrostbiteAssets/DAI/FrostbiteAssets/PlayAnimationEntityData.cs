using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PlayAnimationEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform EntitySpace0 { get; set; }

		[FieldOffset(80, 160)]
		public LinearTransform EntitySpace1 { get; set; }

		[FieldOffset(144, 224)]
		public LinearTransform EntitySpace2 { get; set; }

		[FieldOffset(208, 288)]
		public LinearTransform EntitySpace3 { get; set; }

		[FieldOffset(272, 352)]
		public LinearTransform EntitySpace4 { get; set; }

		[FieldOffset(336, 416)]
		public Realm Realm { get; set; }

		[FieldOffset(340, 424)]
		public ExternalObject<PlayAnimationData> Animation { get; set; }

		[FieldOffset(344, 432)]
		public float ExternalTime { get; set; }

		[FieldOffset(348, 436)]
		public float LifeTime { get; set; }

		[FieldOffset(352, 440)]
		public float AlignValue { get; set; }

		[FieldOffset(356, 444)]
		public bool Replicated { get; set; }
	}
}

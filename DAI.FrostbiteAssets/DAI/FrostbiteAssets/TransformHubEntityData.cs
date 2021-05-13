using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TransformHubEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform In1 { get; set; }

		[FieldOffset(80, 160)]
		public LinearTransform In2 { get; set; }

		[FieldOffset(144, 224)]
		public LinearTransform In3 { get; set; }

		[FieldOffset(208, 288)]
		public LinearTransform In4 { get; set; }

		[FieldOffset(272, 352)]
		public LinearTransform In5 { get; set; }

		[FieldOffset(336, 416)]
		public LinearTransform In6 { get; set; }

		[FieldOffset(400, 480)]
		public LinearTransform In7 { get; set; }

		[FieldOffset(464, 544)]
		public LinearTransform In8 { get; set; }

		[FieldOffset(528, 608)]
		public Realm Realm { get; set; }
	}
}

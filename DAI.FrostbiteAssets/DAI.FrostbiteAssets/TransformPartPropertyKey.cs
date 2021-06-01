using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TransformPartPropertyKey
	{
		[FieldOffset(0, 0)]
		public float Value { get; set; }

		[FieldOffset(4, 4)]
		public AnimTangentType InAnimTangentType { get; set; }

		[FieldOffset(8, 8)]
		public float InAngle { get; set; }

		[FieldOffset(12, 12)]
		public float InWeight { get; set; }

		[FieldOffset(16, 16)]
		public AnimTangentType OutAnimTangentType { get; set; }

		[FieldOffset(20, 20)]
		public float OutAngle { get; set; }

		[FieldOffset(24, 24)]
		public float OutWeight { get; set; }
	}
}

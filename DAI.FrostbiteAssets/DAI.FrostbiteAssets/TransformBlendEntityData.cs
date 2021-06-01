using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TransformBlendEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform In1 { get; set; }

		[FieldOffset(80, 160)]
		public LinearTransform In2 { get; set; }

		[FieldOffset(144, 224)]
		public Realm Realm { get; set; }

		[FieldOffset(148, 228)]
		public float BlendValue { get; set; }

		[FieldOffset(152, 232)]
		public float BlendValue2 { get; set; }
	}
}

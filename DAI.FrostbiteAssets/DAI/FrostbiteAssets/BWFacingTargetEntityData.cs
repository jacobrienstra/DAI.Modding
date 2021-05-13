using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWFacingTargetEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform BaseTransform { get; set; }

		[FieldOffset(80, 160)]
		public LinearTransform TransformOfTarget { get; set; }

		[FieldOffset(144, 224)]
		public Realm Realm { get; set; }

		[FieldOffset(148, 228)]
		public float FieldOfView { get; set; }

		[FieldOffset(152, 232)]
		public bool Enabled { get; set; }
	}
}

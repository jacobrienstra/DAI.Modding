using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TransformToRotationEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform In { get; set; }

		[FieldOffset(80, 160)]
		public Realm Realm { get; set; }

		[FieldOffset(84, 164)]
		public bool Degrees { get; set; }
	}
}

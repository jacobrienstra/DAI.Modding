using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PhysicsDrivenAnimationEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public PhysicsDrivenAnimationEntityBinding Binding { get; set; }

		[FieldOffset(700, 1736)]
		public int AnimationEntitySpacePriority { get; set; }

		[FieldOffset(704, 1740)]
		public bool UseSpineXFor1p { get; set; }
	}
}

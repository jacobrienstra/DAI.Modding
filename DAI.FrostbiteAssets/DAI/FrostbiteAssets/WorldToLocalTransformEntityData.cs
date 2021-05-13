using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class WorldToLocalTransformEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform WorldTransform { get; set; }

		[FieldOffset(80, 160)]
		public Realm Realm { get; set; }

		[FieldOffset(84, 164)]
		public bool AutoUpdate { get; set; }

		[FieldOffset(85, 165)]
		public bool ForceTransformation { get; set; }
	}
}

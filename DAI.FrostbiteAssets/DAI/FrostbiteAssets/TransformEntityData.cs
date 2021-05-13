using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TransformEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform DefaultTransform { get; set; }

		[FieldOffset(80, 160)]
		public Realm Realm { get; set; }
	}
}

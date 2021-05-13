using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWTransformVariableEntityData : BWVariableEntityBaseData
	{
		[FieldOffset(20, 112)]
		public Realm Realm { get; set; }

		[FieldOffset(32, 128)]
		public LinearTransform InputValue { get; set; }
	}
}

using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWVec4VariableEntityData : BWVariableEntityBaseData
	{
		[FieldOffset(20, 112)]
		public Realm Realm { get; set; }

		[FieldOffset(32, 128)]
		public Vec4 InputValue { get; set; }
	}
}

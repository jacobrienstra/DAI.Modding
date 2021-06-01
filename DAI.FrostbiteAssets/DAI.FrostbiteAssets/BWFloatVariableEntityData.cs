using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWFloatVariableEntityData : BWVariableEntityBaseData
	{
		[FieldOffset(20, 112)]
		public Realm Realm { get; set; }

		[FieldOffset(24, 116)]
		public float InputValue { get; set; }
	}
}

using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWBooleanVariableEntityData : BWVariableEntityBaseData
	{
		[FieldOffset(20, 112)]
		public Realm Realm { get; set; }

		[FieldOffset(24, 116)]
		public bool InputValue { get; set; }
	}
}

using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_InputAction : BoolProvider
	{
		[FieldOffset(8, 32)]
		public int Action { get; set; }

		[FieldOffset(12, 36)]
		public DataProvider_InputActionConditions Condition { get; set; }

		[FieldOffset(16, 40)]
		public float Time { get; set; }
	}
}

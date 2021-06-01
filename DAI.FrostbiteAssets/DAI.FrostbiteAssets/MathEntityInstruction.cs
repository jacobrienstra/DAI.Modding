using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MathEntityInstruction
	{
		[FieldOffset(0, 0)]
		public MathOpCode Code { get; set; }

		[FieldOffset(4, 4)]
		public int Result { get; set; }

		[FieldOffset(8, 8)]
		public int Param1 { get; set; }

		[FieldOffset(12, 12)]
		public int Param2 { get; set; }
	}
}

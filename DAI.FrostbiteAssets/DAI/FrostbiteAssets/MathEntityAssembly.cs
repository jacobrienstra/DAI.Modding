using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MathEntityAssembly : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<MathEntityFunctionCall> FunctionCalls { get; set; }

		[FieldOffset(4, 8)]
		public List<MathEntityInstruction> Instructions { get; set; }

		public MathEntityAssembly()
		{
			FunctionCalls = new List<MathEntityFunctionCall>();
			Instructions = new List<MathEntityInstruction>();
		}
	}
}

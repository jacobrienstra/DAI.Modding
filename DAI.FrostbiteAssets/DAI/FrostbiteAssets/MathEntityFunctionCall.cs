using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MathEntityFunctionCall : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<uint> Parameters { get; set; }

		public MathEntityFunctionCall()
		{
			Parameters = new List<uint>();
		}
	}
}

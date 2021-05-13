using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MathIntOpEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public List<IntMathOp> Operators { get; set; }

		public MathIntOpEntityData()
		{
			Operators = new List<IntMathOp>();
		}
	}
}

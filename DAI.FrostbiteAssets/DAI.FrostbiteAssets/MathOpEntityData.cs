using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MathOpEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public List<MathOp> Operators { get; set; }

		public MathOpEntityData()
		{
			Operators = new List<MathOp>();
		}
	}
}

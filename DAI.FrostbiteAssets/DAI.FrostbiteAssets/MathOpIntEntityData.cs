using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MathOpIntEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public List<MathOpInt> Operators { get; set; }

		public MathOpIntEntityData()
		{
			Operators = new List<MathOpInt>();
		}
	}
}

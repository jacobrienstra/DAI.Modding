using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SelectPropertyEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public List<string> Inputs { get; set; }

		[FieldOffset(24, 112)]
		public int InputSelect { get; set; }

		public SelectPropertyEntityData()
		{
			Inputs = new List<string>();
		}
	}
}

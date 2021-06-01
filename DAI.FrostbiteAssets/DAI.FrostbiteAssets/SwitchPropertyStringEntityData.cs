using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SwitchPropertyStringEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<string> StringProperties { get; set; }

		[FieldOffset(20, 104)]
		public Realm Realm { get; set; }

		public SwitchPropertyStringEntityData()
		{
			StringProperties = new List<string>();
		}
	}
}

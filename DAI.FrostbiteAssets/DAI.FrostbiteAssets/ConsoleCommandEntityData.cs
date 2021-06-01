using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConsoleCommandEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<string> Commands { get; set; }

		[FieldOffset(20, 104)]
		public Realm Realm { get; set; }

		public ConsoleCommandEntityData()
		{
			Commands = new List<string>();
		}
	}
}

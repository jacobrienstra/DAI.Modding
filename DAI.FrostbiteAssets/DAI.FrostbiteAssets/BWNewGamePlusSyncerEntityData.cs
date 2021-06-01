using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWNewGamePlusSyncerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public List<ExternalObject<BWNewGamePlusSyncerEntityData>> Sets { get; set; }

		public BWNewGamePlusSyncerEntityData()
		{
			Sets = new List<ExternalObject<BWNewGamePlusSyncerEntityData>>();
		}
	}
}

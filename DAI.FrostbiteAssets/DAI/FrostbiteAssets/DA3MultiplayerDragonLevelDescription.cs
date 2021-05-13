using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3MultiplayerDragonLevelDescription : LevelDescriptionComponent
	{
		[FieldOffset(8, 24)]
		public List<DA3MPDragonLevelVariant> DragonVariants { get; set; }

		public DA3MultiplayerDragonLevelDescription()
		{
			DragonVariants = new List<DA3MPDragonLevelVariant>();
		}
	}
}

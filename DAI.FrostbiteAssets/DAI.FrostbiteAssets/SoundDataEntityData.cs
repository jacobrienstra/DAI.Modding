using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundDataEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<GameObjectData>> DataAssets { get; set; }

		public SoundDataEntityData()
		{
			DataAssets = new List<ExternalObject<GameObjectData>>();
		}
	}
}

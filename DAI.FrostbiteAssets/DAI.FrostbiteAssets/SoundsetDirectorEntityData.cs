using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundsetDirectorEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<LogicPrefabReferenceObjectData>> FilterData { get; set; }

		public SoundsetDirectorEntityData()
		{
			FilterData = new List<ExternalObject<LogicPrefabReferenceObjectData>>();
		}
	}
}

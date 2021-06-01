using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ExertionDirectorEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<LogicPrefabReferenceObjectData>> FilterData { get; set; }

		public ExertionDirectorEntityData()
		{
			FilterData = new List<ExternalObject<LogicPrefabReferenceObjectData>>();
		}
	}
}

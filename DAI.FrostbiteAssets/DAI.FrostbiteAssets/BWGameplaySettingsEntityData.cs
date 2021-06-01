using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWGameplaySettingsEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<LogicReferenceObjectData>> GameplaySettings { get; set; }

		public BWGameplaySettingsEntityData()
		{
			GameplaySettings = new List<ExternalObject<LogicReferenceObjectData>>();
		}
	}
}

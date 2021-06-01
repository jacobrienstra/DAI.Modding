using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PrefabBlueprint : Blueprint
	{
		[FieldOffset(32, 176)]
		public List<ExternalObject<GameObjectData>> Objects { get; set; }

		[FieldOffset(36, 184)]
		public TimeDeltaType TimeDeltaType { get; set; }

		public PrefabBlueprint()
		{
			Objects = new List<ExternalObject<GameObjectData>>();
		}
	}
}

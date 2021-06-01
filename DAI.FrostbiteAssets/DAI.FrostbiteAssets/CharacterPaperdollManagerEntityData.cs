using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CharacterPaperdollManagerEntityData : PaperdollManagerEntityData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<SpatialPrefabBlueprint> OmniPaperdollPrefab { get; set; }

		[FieldOffset(100, 184)]
		public List<FollowerNamePreview> FollowerNames { get; set; }

		[FieldOffset(104, 192)]
		public bool UseOmniPaperdoll { get; set; }

		public CharacterPaperdollManagerEntityData()
		{
			FollowerNames = new List<FollowerNamePreview>();
		}
	}
}

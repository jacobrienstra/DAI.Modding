using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharGenPaperdollManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<LogicPrefabReferenceObjectData>> SliderConfigurations { get; set; }

		[FieldOffset(20, 104)]
		public CharGenPaperdollCameraControls CameraControl { get; set; }

		[FieldOffset(36, 120)]
		public int GenderOverride { get; set; }

		[FieldOffset(40, 124)]
		public int RaceOverride { get; set; }

		[FieldOffset(44, 128)]
		public float UploadChargenDataTimeoutInSeconds { get; set; }

		[FieldOffset(48, 136)]
		public NonEnglishToEnglishHashes NonEnglishToEnglishHashes { get; set; }

		public CharGenPaperdollManagerEntityData()
		{
			SliderConfigurations = new List<ExternalObject<LogicPrefabReferenceObjectData>>();
		}
	}
}

using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpatialSoundAreaEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<SoundAsset> Sound { get; set; }

		[FieldOffset(20, 104)]
		public List<ExternalObject<GameObjectData>> AdditionalSounds { get; set; }

		[FieldOffset(24, 112)]
		public ExternalObject<BigWorldSettingsAsset> BigWorld { get; set; }

		[FieldOffset(28, 120)]
		public List<ExternalObject<GameObjectData>> AdditionalBigWorlds { get; set; }

		[FieldOffset(32, 128)]
		public float FadeWidth { get; set; }

		[FieldOffset(36, 132)]
		public float ProximityMultiplier { get; set; }

		[FieldOffset(40, 136)]
		public FadeCurveType FadeCurve { get; set; }

		[FieldOffset(44, 140)]
		public uint Priority { get; set; }

		[FieldOffset(48, 144)]
		public float ReverbFadeWidth { get; set; }

		[FieldOffset(52, 148)]
		public FadeCurveType ReverbFadeCurve { get; set; }

		[FieldOffset(56, 152)]
		public uint ReverbPriority { get; set; }

		[FieldOffset(60, 156)]
		public bool UsePriority { get; set; }

		[FieldOffset(61, 157)]
		public bool FacePlayerEnabled { get; set; }

		[FieldOffset(62, 158)]
		public bool IsActive { get; set; }

		[FieldOffset(63, 159)]
		public bool IgnoreVerticalFadeWidth { get; set; }

		[FieldOffset(64, 160)]
		public bool ReverbUsePriority { get; set; }

		public SpatialSoundAreaEntityData()
		{
			AdditionalSounds = new List<ExternalObject<GameObjectData>>();
			AdditionalBigWorlds = new List<ExternalObject<GameObjectData>>();
		}
	}
}

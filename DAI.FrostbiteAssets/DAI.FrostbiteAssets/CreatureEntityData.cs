using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CreatureEntityData : CharacterEntityData
	{
		[FieldOffset(192, 320)]
		public MaterialDecl FootMaterialPair { get; set; }

		[FieldOffset(196, 336)]
		public MaterialDecl HeadMaterialPair { get; set; }

		[FieldOffset(200, 352)]
		public ExternalObject<Dummy> HeadCollision { get; set; }

		[FieldOffset(204, 360)]
		public ExternalObject<CharacterPhysicsData> CharacterPhysics { get; set; }

		[FieldOffset(208, 368)]
		public List<CreatureMeshData> Meshes1p { get; set; }

		[FieldOffset(212, 376)]
		public List<CreatureMeshData> Meshes3p { get; set; }

		[FieldOffset(216, 384)]
		public ExternalObject<BWHealthModuleData> HealthModule { get; set; }

		[FieldOffset(220, 392)]
		public UITextureAtlasTextureReference PortraitIcon { get; set; }

		[FieldOffset(240, 432)]
		public UITextureAtlasTextureReference LowHealthPortraitIcon { get; set; }

		[FieldOffset(260, 472)]
		public int LowHealthPortraitThreshold { get; set; }

		[FieldOffset(264, 480)]
		public LocalizedStringReference CharacterNameReference { get; set; }

		[FieldOffset(268, 504)]
		public int PartyMemberID { get; set; }

		[FieldOffset(272, 512)]
		public ExternalObject<CreatureClass> Class { get; set; }

		[FieldOffset(276, 520)]
		public float MoveSpeedModifier { get; set; }

		[FieldOffset(280, 528)]
		public ExternalObject<CharacterBlueprint> PaperdollCharacter { get; set; }

		[FieldOffset(284, 536)]
		public string KilledStatItem { get; set; }

		[FieldOffset(288, 544)]
		public ExternalObject<BWDepletableStat> HealthStat { get; set; }

		[FieldOffset(292, 552)]
		public ExternalObject<BWDepletableStat> ResurrectStat { get; set; }

		[FieldOffset(296, 560)]
		public float PhysicalRadiusInCombat { get; set; }

		[FieldOffset(300, 564)]
		public int LineOfSightSourceBone { get; set; }

		[FieldOffset(304, 568)]
		public int LineOfSightTargetBone { get; set; }

		[FieldOffset(308, 572)]
		public int AnimationControlledTransformBone { get; set; }

		[FieldOffset(312, 576)]
		public float AnimationControlledBoundingBoxSize { get; set; }

		[FieldOffset(316, 584)]
		public CreatureEntityBinding CreatureBinding { get; set; }

		[FieldOffset(456, 920)]
		public ExternalObject<TraversalProperties> TraversalProperties { get; set; }

		[FieldOffset(460, 928)]
		public float SpeedCapPercent { get; set; }

		[FieldOffset(464, 932)]
		public int EnemyType { get; set; }

		[FieldOffset(468, 936)]
		public QualityScalableFloat CullDistanceDuringCombat { get; set; }

		[FieldOffset(484, 952)]
		public float NearCullDistance { get; set; }

		[FieldOffset(488, 956)]
		public QualityScalableInt MeshLodBiasDuringCombat { get; set; }

		[FieldOffset(504, 972)]
		public QualityScalableFloat AnimationMediumLodDistance { get; set; }

		[FieldOffset(520, 988)]
		public QualityScalableFloat AnimationLowLodDistance { get; set; }

		[FieldOffset(536, 1004)]
		public QualityScalableFloat AnimationMediumLodDistanceDuringCombat { get; set; }

		[FieldOffset(552, 1020)]
		public QualityScalableFloat AnimationLowLodDistanceDuringCombat { get; set; }

		[FieldOffset(568, 1036)]
		public bool ProximityCheck { get; set; }

		[FieldOffset(569, 1037)]
		public bool FreeSpaceCheck { get; set; }

		[FieldOffset(570, 1038)]
		public bool CollisionEnabled { get; set; }

		[FieldOffset(571, 1039)]
		public bool PhysicsControlled { get; set; }

		[FieldOffset(572, 1040)]
		public bool IsPushable { get; set; }

		[FieldOffset(573, 1041)]
		public bool IsBoss { get; set; }

		[FieldOffset(574, 1042)]
		public bool UseCustomNearCullDistance { get; set; }

		public CreatureEntityData()
		{
			Meshes1p = new List<CreatureMeshData>();
			Meshes3p = new List<CreatureMeshData>();
		}
	}
}

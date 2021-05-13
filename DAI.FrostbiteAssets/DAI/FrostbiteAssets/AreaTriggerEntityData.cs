using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class AreaTriggerEntityData : TriggerEntityData
	{
		[FieldOffset(96, 192)]
		public LinearTransform GeometryTransform { get; set; }

		[FieldOffset(160, 256)]
		public AreaTriggerInclude Include { get; set; }

		[FieldOffset(164, 260)]
		public float Radius { get; set; }

		[FieldOffset(168, 264)]
		public float InsideAreaEventRepeatTime { get; set; }

		[FieldOffset(172, 268)]
		public TeamId TeamOfAllies { get; set; }

		[FieldOffset(176, 272)]
		public bool LinkToSpatialEntityToFollowPostInit { get; set; }

		[FieldOffset(177, 273)]
		public bool UseCharacterEntity { get; set; }

		[FieldOffset(178, 274)]
		public bool UseRadiusWithGeometryTransform { get; set; }

		[FieldOffset(179, 275)]
		public bool OneInsideAreaEventPerSoldier { get; set; }

		[FieldOffset(180, 276)]
		public bool TriggerOnlyOnLeave { get; set; }

		[FieldOffset(181, 277)]
		public bool ResetOnEnable { get; set; }

		[FieldOffset(182, 278)]
		public bool TriggerOnLeaveOnDeath { get; set; }

		[FieldOffset(183, 279)]
		public bool TriggerOnLeaveOnDisable { get; set; }
	}
}

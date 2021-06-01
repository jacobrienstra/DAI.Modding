using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWAreaTriggerEntityData : AreaTriggerBaseData
	{
		[FieldOffset(176, 272)]
		public BWAreaTriggerInclude Include { get; set; }

		[FieldOffset(180, 276)]
		public float Radius { get; set; }

		[FieldOffset(184, 280)]
		public float InsideAreaEventRepeatTime { get; set; }

		[FieldOffset(188, 284)]
		public TeamId TeamOfAllies { get; set; }

		[FieldOffset(192, 288)]
		public bool OneInsideAreaEventPerSoldier { get; set; }

		[FieldOffset(193, 289)]
		public bool TriggerOnlyOnLeave { get; set; }

		[FieldOffset(194, 290)]
		public bool ResetOnEnable { get; set; }

		[FieldOffset(195, 291)]
		public bool TriggerOnLeaveOnDeath { get; set; }

		[FieldOffset(196, 292)]
		public bool TriggerOnLeaveOnDisable { get; set; }

		[FieldOffset(197, 293)]
		public bool AllowDeadCharacters { get; set; }

		[FieldOffset(198, 294)]
		public bool Exclusive { get; set; }

		[FieldOffset(199, 295)]
		public bool UsePlayerPositionWithMount { get; set; }

		[FieldOffset(200, 296)]
		public bool UseTargetPosition { get; set; }
	}
}

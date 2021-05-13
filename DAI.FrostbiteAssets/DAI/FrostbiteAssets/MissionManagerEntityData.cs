namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MissionManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public PlotFlagReference AgentsFlag { get; set; }

		[FieldOffset(32, 136)]
		public PlotFlagReference PowerFlag { get; set; }

		[FieldOffset(48, 176)]
		public PlotFlagReference AgentsDiscountFlag { get; set; }

		[FieldOffset(64, 216)]
		public PlotFlagReference PreInquisitionJoinedFlag { get; set; }

		[FieldOffset(80, 256)]
		public PlotFlagReference PreInquisitionJoinedXPFlag { get; set; }

		[FieldOffset(96, 296)]
		public PlotFlagReference ConnectionsSpecialistUsageFlag { get; set; }

		[FieldOffset(112, 336)]
		public PlotFlagReference SecretsSpecialistUsageFlag { get; set; }

		[FieldOffset(128, 376)]
		public PlotFlagReference ForcesSpecialistUsageFlag { get; set; }

		[FieldOffset(144, 416)]
		public PlotFlagReference ConnectionsDiscountFlag { get; set; }

		[FieldOffset(160, 456)]
		public PlotFlagReference SecretsDiscountFlag { get; set; }

		[FieldOffset(176, 496)]
		public PlotFlagReference ForcesDiscountFlag { get; set; }

		[FieldOffset(192, 536)]
		public PlotFlagReference OperationNotificationsDisabledFlag { get; set; }

		[FieldOffset(208, 576)]
		public float PreferredSpecialistDiscount { get; set; }

		[FieldOffset(212, 584)]
		public LocalizedStringReference LevelConfirmationString { get; set; }

		[FieldOffset(216, 608)]
		public LocalizedStringReference LevelConfirmButtonString { get; set; }

		[FieldOffset(220, 632)]
		public LocalizedStringReference LevelCancelButtonString { get; set; }

		[FieldOffset(224, 656)]
		public LocalizedStringReference LevelTitleString { get; set; }
	}
}

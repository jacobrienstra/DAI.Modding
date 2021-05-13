namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIPartyCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public UIPartyCommandData ClearBehaviorCommand { get; set; }

		[FieldOffset(64, 248)]
		public UIPartyCommandData HoldPositionCommand { get; set; }

		[FieldOffset(96, 360)]
		public UIPartyCommandData AttackMyTargetCommand { get; set; }

		[FieldOffset(128, 472)]
		public UIPartyCommandData ComeToMeCommand { get; set; }

		[FieldOffset(160, 584)]
		public UIPartyCommandData DisengageCommand { get; set; }
	}
}

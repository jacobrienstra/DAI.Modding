namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BlackfootHUDPlayerStatusBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo PlayerHealthPercentage { get; set; }

		[FieldOffset(24, 56)]
		public UIDataSourceInfo MaxPlayerHealth { get; set; }

		[FieldOffset(40, 88)]
		public UIDataSourceInfo PlayerAbilityResourcePercentage { get; set; }

		[FieldOffset(56, 120)]
		public UIDataSourceInfo PlayerAbilityResourceType { get; set; }

		[FieldOffset(72, 152)]
		public UIDataSourceInfo PlayerName { get; set; }

		[FieldOffset(88, 184)]
		public UIDataSourceInfo PlayerPortrait { get; set; }

		[FieldOffset(104, 216)]
		public UIDataSourceInfo PlayerSelected { get; set; }

		[FieldOffset(120, 248)]
		public UIDataSourceInfo PortraitOverlay { get; set; }

		[FieldOffset(136, 280)]
		public UIDataSourceInfo IsPlayerInConversation { get; set; }

		[FieldOffset(152, 312)]
		public UIDataSourceInfo Visible { get; set; }

		[FieldOffset(168, 344)]
		public UIDataSourceInfo PlayerSelectedAsTarget { get; set; }

		[FieldOffset(184, 376)]
		public UIDataSourceInfo Barrier { get; set; }

		[FieldOffset(200, 408)]
		public UIDataSourceInfo Armor { get; set; }

		[FieldOffset(216, 440)]
		public UIDataSourceInfo UseMultiplayerLogic { get; set; }

		[FieldOffset(232, 472)]
		public UIDataSourceInfo QueuedCommand { get; set; }

		[FieldOffset(248, 504)]
		public UIDataSourceInfo PartySize { get; set; }

		[FieldOffset(264, 536)]
		public UIDataSourceInfo IsLowHealth { get; set; }
	}
}

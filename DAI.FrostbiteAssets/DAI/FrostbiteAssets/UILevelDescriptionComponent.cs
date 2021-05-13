namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UILevelDescriptionComponent : LevelDescriptionComponent
	{
		[FieldOffset(8, 24)]
		public ExternalObject<Dummy> LoadingMusic { get; set; }

		[FieldOffset(12, 32)]
		public string LoadingMusicPath { get; set; }

		[FieldOffset(16, 48)]
		public UIMinimapData MinimapData { get; set; }

		[FieldOffset(224, 272)]
		public string LevelImagePath { get; set; }

		[FieldOffset(228, 280)]
		public string ScreenshotPath { get; set; }

		[FieldOffset(232, 288)]
		public LocalizedStringReference LocationName { get; set; }

		[FieldOffset(236, 312)]
		public UILevelStatData LevelCompletedStatData { get; set; }

		[FieldOffset(252, 344)]
		public UILevelStatData LevelScoreStatData { get; set; }

		[FieldOffset(268, 376)]
		public int SortIndex { get; set; }

		[FieldOffset(272, 384)]
		public UIGPSPosition GPSPosition { get; set; }

		[FieldOffset(296, 408)]
		public ExternalObject<UILevelLoadData> LevelLoadData { get; set; }

		[FieldOffset(300, 416)]
		public bool IsMenuLevel { get; set; }

		[FieldOffset(301, 417)]
		public bool LoadingMusicAutomaticStop { get; set; }
	}
}

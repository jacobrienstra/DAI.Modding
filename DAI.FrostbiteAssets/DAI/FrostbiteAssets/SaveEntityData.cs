namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SaveEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<Dummy> SaveScreenTexture { get; set; }

		[FieldOffset(20, 104)]
		public string LevelName { get; set; }

		[FieldOffset(24, 112)]
		public string SaveFileName { get; set; }

		[FieldOffset(28, 120)]
		public string SaveNameSID { get; set; }

		[FieldOffset(32, 128)]
		public bool CheckForHumanPlayer { get; set; }
	}
}

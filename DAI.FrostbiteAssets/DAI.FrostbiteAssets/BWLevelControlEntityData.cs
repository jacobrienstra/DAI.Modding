namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWLevelControlEntityData : LevelControlEntityData
	{
		[FieldOffset(44, 136)]
		public int StartPointID { get; set; }

		[FieldOffset(48, 144)]
		public string AlternateLoadingAssetPath { get; set; }

		[FieldOffset(52, 152)]
		public bool Enabled { get; set; }
	}
}

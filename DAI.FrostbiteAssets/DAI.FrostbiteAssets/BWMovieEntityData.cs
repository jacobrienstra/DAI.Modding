namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMovieEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<MovieTextureAsset> Movie { get; set; }

		[FieldOffset(20, 104)]
		public bool AllowSkip { get; set; }

		[FieldOffset(21, 105)]
		public bool Looping { get; set; }

		[FieldOffset(22, 106)]
		public bool DisableSoundEffects { get; set; }

		[FieldOffset(23, 107)]
		public bool FireOnFinishWhenStopped { get; set; }
	}
}

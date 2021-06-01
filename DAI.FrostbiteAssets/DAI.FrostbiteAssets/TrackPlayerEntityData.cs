namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TrackPlayerEntityData : GameComponentEntityData
	{
		[FieldOffset(112, 208)]
		public bool RandomizeTracker { get; set; }
	}
}

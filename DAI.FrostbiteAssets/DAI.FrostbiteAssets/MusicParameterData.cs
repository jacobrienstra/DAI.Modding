namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicParameterData : MusicInputData
	{
		[FieldOffset(16, 40)]
		public float DefaultValue { get; set; }
	}
}

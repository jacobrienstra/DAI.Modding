namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class MoverTuneComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public MoverTuneMap MoverTuneMap { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ReadBoolGameState : ReadAntGameStateData
	{
		[FieldOffset(12, 56)]
		public AntRef GameState { get; set; }
	}
}

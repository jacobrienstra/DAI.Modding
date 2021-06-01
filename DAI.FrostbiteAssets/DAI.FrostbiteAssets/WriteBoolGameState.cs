namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WriteBoolGameState : WriteAntGameStateData
	{
		[FieldOffset(12, 56)]
		public AntRef GameState { get; set; }

		[FieldOffset(32, 104)]
		public bool Value { get; set; }
	}
}

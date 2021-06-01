namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class WriteVector3GameState : WriteAntGameStateData
	{
		[FieldOffset(12, 56)]
		public AntRef GameState { get; set; }

		[FieldOffset(32, 112)]
		public Vec3 Value { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameModeTeamSize
	{
		[FieldOffset(0, 0)]
		public uint PlayerCount { get; set; }

		[FieldOffset(4, 4)]
		public uint SquadSize { get; set; }
	}
}

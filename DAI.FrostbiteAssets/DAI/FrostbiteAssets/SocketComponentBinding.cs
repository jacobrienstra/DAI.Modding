namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SocketComponentBinding : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntRef MirrorGameState { get; set; }
	}
}

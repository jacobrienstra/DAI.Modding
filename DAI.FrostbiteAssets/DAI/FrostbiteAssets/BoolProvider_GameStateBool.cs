namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_GameStateBool : BWConditional
	{
		[FieldOffset(8, 32)]
		public AntRef GameStateBool { get; set; }

		[FieldOffset(28, 80)]
		public int Animatable { get; set; }
	}
}

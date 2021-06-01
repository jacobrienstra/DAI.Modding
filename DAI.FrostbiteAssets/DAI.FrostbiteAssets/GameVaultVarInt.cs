namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameVaultVarInt : DataContainer
	{
		[FieldOffset(8, 24)]
		public PlotFlagReference PlotFlag { get; set; }

		[FieldOffset(24, 64)]
		public string VariableNameOnServer { get; set; }

		[FieldOffset(28, 72)]
		public int DefaultValue { get; set; }

		[FieldOffset(32, 76)]
		public int MinValue { get; set; }

		[FieldOffset(36, 80)]
		public int MaxValue { get; set; }
	}
}

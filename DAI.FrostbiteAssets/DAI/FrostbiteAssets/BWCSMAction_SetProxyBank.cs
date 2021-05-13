namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetProxyBank : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public AntRef BankPointer { get; set; }

		[FieldOffset(48, 120)]
		public AntRef ProxyBank { get; set; }

		[FieldOffset(68, 168)]
		public ExternalObject<Dummy> Entity { get; set; }

		[FieldOffset(72, 176)]
		public int Animatable { get; set; }
	}
}

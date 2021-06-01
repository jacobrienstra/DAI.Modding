namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_DA3SearchHighlight : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<TransformProvider_Self> Target { get; set; }

		[FieldOffset(32, 80)]
		public float Radius { get; set; }

		[FieldOffset(36, 84)]
		public uint HashedOnFoundEvent { get; set; }

		[FieldOffset(40, 88)]
		public uint HashedOnNotFoundEvent { get; set; }

		[FieldOffset(44, 92)]
		public bool CheckLOS { get; set; }
	}
}

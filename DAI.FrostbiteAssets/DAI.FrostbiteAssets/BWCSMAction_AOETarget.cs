namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_AOETarget : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public float Radius { get; set; }

		[FieldOffset(32, 80)]
		public Vec3 Offset { get; set; }
	}
}

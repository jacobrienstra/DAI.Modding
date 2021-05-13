namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIRadialMenuBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo DynamicItems { get; set; }

		[FieldOffset(24, 56)]
		public float DeadZone { get; set; }

		[FieldOffset(28, 60)]
		public float AffectedHalfAngle { get; set; }
	}
}

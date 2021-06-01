namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIElementReadyUpTextFieldEntityData : UIElementTextFieldEntityExData
	{
		[FieldOffset(272, 432)]
		public Vec3 CriticalRGB { get; set; }

		[FieldOffset(288, 448)]
		public bool IsCritical { get; set; }
	}
}

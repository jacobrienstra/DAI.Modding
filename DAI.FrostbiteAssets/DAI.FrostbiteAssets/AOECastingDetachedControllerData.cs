namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class AOECastingDetachedControllerData : CinebotControllerData
	{
		[FieldOffset(24, 112)]
		public float FOV { get; set; }

		[FieldOffset(32, 128)]
		public Vec3 Offset { get; set; }
	}
}

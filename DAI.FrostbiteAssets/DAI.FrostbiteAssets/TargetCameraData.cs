namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TargetCameraData : CameraData
	{
		[FieldOffset(80, 160)]
		public HudData Hud { get; set; }
	}
}

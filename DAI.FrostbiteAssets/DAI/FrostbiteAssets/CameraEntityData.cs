namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CameraEntityData : CameraEntityBaseData
	{
		[FieldOffset(128, 224)]
		public float Fov { get; set; }
	}
}

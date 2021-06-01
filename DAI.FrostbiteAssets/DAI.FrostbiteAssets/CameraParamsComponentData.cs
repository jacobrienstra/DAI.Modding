using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CameraParamsComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Realm Realm { get; set; }

		[FieldOffset(116, 196)]
		public float ViewDistance { get; set; }

		[FieldOffset(120, 200)]
		public float NearPlane { get; set; }

		[FieldOffset(124, 204)]
		public float SunShadowmapViewDistance { get; set; }
	}
}

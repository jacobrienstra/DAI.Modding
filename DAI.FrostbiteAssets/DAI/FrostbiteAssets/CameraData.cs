namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CameraData : GameObjectData
	{
		[FieldOffset(16, 96)]
		public Vec3 OcclusionRayOffset { get; set; }

		[FieldOffset(32, 112)]
		public float PreFadeTime { get; set; }

		[FieldOffset(36, 116)]
		public float FadeTime { get; set; }

		[FieldOffset(40, 120)]
		public float FadeWaitTime { get; set; }

		[FieldOffset(44, 124)]
		public float NearPlane { get; set; }

		[FieldOffset(48, 128)]
		public float ShadowViewDistanceScale { get; set; }

		[FieldOffset(52, 132)]
		public float SoundOcclusion { get; set; }

		[FieldOffset(56, 136)]
		public float SoundListenerRadius { get; set; }

		[FieldOffset(60, 140)]
		public float SoundListenerFov { get; set; }

		[FieldOffset(64, 144)]
		public float ShakeFactor { get; set; }

		[FieldOffset(68, 148)]
		public bool StayFadedWhileStreaming { get; set; }
	}
}

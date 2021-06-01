namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIMinimapData : LinkObject
	{
		[FieldOffset(0, 0)]
		public UIMinimapDistanceFieldParams Detail { get; set; }

		[FieldOffset(64, 64)]
		public UIMinimapDistanceFieldParams Vegetation { get; set; }

		[FieldOffset(128, 128)]
		public Vec4 CombatAreaColor { get; set; }

		[FieldOffset(144, 144)]
		public ExternalObject<Dummy> FadeTexture { get; set; }

		[FieldOffset(148, 152)]
		public ExternalObject<Dummy> AirRadarFadeTexture { get; set; }

		[FieldOffset(152, 160)]
		public Vec2 WorldCenter { get; set; }

		[FieldOffset(160, 168)]
		public float WorldSize { get; set; }

		[FieldOffset(164, 172)]
		public float WorldRotation { get; set; }

		[FieldOffset(168, 176)]
		public float WorldRange { get; set; }

		[FieldOffset(172, 180)]
		public float CombatAreaFadeSpeed { get; set; }

		[FieldOffset(176, 184)]
		public float CombatAreaAlphaThreshold { get; set; }

		[FieldOffset(180, 188)]
		public float CombatAreaDistanceScale { get; set; }

		[FieldOffset(184, 192)]
		public ExternalObject<Dummy> CombatAreaMultiplyTexture { get; set; }

		[FieldOffset(188, 200)]
		public Vec2 CombatAreaMultiplyWrapAmount { get; set; }

		[FieldOffset(196, 208)]
		public float AirRadarRange { get; set; }

		[FieldOffset(200, 212)]
		public bool UseCombatAreaTexture { get; set; }
	}
}

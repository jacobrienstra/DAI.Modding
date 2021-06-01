namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class HudData : LinkObject
	{
		[FieldOffset(0, 0)]
		public float CrosshairScaleMin { get; set; }

		[FieldOffset(4, 4)]
		public float CrosshairScaleMax { get; set; }

		[FieldOffset(8, 8)]
		public float CrosshairOpacityMin { get; set; }

		[FieldOffset(12, 12)]
		public float CrosshairOpacityMax { get; set; }

		[FieldOffset(16, 16)]
		public float CrosshairOpacityModifier { get; set; }

		[FieldOffset(20, 24)]
		public string CrosshairTypeId { get; set; }

		[FieldOffset(24, 32)]
		public ExternalObject<Dummy> CrosshairType { get; set; }

		[FieldOffset(28, 40)]
		public ExternalObject<Dummy> LockingType { get; set; }

		[FieldOffset(32, 48)]
		public string WeaponClass { get; set; }

		[FieldOffset(36, 56)]
		public float LowAmmoWarning { get; set; }

		[FieldOffset(40, 60)]
		public float ReloadPrompt { get; set; }

		[FieldOffset(44, 64)]
		public int RenderTargetIndex { get; set; }

		[FieldOffset(48, 72)]
		public ExternalObject<Dummy> HudPropertyList { get; set; }

		[FieldOffset(52, 80)]
		public float SeaLevelAltFreq { get; set; }

		[FieldOffset(56, 84)]
		public float CameraShakeModifier { get; set; }

		[FieldOffset(60, 88)]
		public string HudIcon { get; set; }

		[FieldOffset(64, 96)]
		public bool ShowMinimap { get; set; }

		[FieldOffset(65, 97)]
		public bool HideAmmo { get; set; }

		[FieldOffset(66, 98)]
		public bool InfiniteAmmo { get; set; }

		[FieldOffset(67, 99)]
		public bool HideCrosshairWhenAimOnFriend { get; set; }

		[FieldOffset(68, 100)]
		public bool UseRenderTarget { get; set; }

		[FieldOffset(69, 101)]
		public bool UseRangeMeter { get; set; }

		[FieldOffset(70, 102)]
		public bool UseAimWarning { get; set; }

		[FieldOffset(71, 103)]
		public bool UsePredictedSight { get; set; }

		[FieldOffset(72, 104)]
		public bool UseWeaponOrientations { get; set; }

		[FieldOffset(73, 105)]
		public bool UseVelocityVectorMarker { get; set; }

		[FieldOffset(74, 106)]
		public bool UseLockingController { get; set; }

		[FieldOffset(75, 107)]
		public bool UseThrust { get; set; }

		[FieldOffset(76, 108)]
		public bool UseGForce { get; set; }

		[FieldOffset(77, 109)]
		public bool UseSkidSlip { get; set; }

		[FieldOffset(78, 110)]
		public bool UseClimbRate { get; set; }
	}
}

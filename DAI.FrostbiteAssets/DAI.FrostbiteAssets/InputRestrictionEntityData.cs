namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InputRestrictionEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public bool OverridePreviousInputRestriction { get; set; }

		[FieldOffset(17, 97)]
		public bool ApplyRestrictionsToSpecificPlayer { get; set; }

		[FieldOffset(18, 98)]
		public bool Throttle { get; set; }

		[FieldOffset(19, 99)]
		public bool Strafe { get; set; }

		[FieldOffset(20, 100)]
		public bool Brake { get; set; }

		[FieldOffset(21, 101)]
		public bool HandBrake { get; set; }

		[FieldOffset(22, 102)]
		public bool Clutch { get; set; }

		[FieldOffset(23, 103)]
		public bool Yaw { get; set; }

		[FieldOffset(24, 104)]
		public bool Pitch { get; set; }

		[FieldOffset(25, 105)]
		public bool Roll { get; set; }

		[FieldOffset(26, 106)]
		public bool Fire { get; set; }

		[FieldOffset(27, 107)]
		public bool FireCountermeasure { get; set; }

		[FieldOffset(28, 108)]
		public bool AltFire { get; set; }

		[FieldOffset(29, 109)]
		public bool CycleRadioChannel { get; set; }

		[FieldOffset(30, 110)]
		public bool SelectMeleeWeapon { get; set; }

		[FieldOffset(31, 111)]
		public bool Zoom { get; set; }

		[FieldOffset(32, 112)]
		public bool Jump { get; set; }

		[FieldOffset(33, 113)]
		public bool ChangeVehicle { get; set; }

		[FieldOffset(34, 114)]
		public bool ChangeEntry { get; set; }

		[FieldOffset(35, 115)]
		public bool ChangePose { get; set; }

		[FieldOffset(36, 116)]
		public bool ChangeWeapon { get; set; }

		[FieldOffset(37, 117)]
		public bool Reload { get; set; }

		[FieldOffset(38, 118)]
		public bool ToggleCamera { get; set; }

		[FieldOffset(39, 119)]
		public bool Sprint { get; set; }

		[FieldOffset(40, 120)]
		public bool ScoreboardMenu { get; set; }

		[FieldOffset(41, 121)]
		public bool MapZoom { get; set; }

		[FieldOffset(42, 122)]
		public bool GearUp { get; set; }

		[FieldOffset(43, 123)]
		public bool GearDown { get; set; }

		[FieldOffset(44, 124)]
		public bool ThreeDimensionalMap { get; set; }

		[FieldOffset(45, 125)]
		public bool GiveOrder { get; set; }

		[FieldOffset(46, 126)]
		public bool Prone { get; set; }

		[FieldOffset(47, 127)]
		public bool SwitchPrimaryInventory { get; set; }

		[FieldOffset(48, 128)]
		public bool SwitchPrimaryWeapon { get; set; }

		[FieldOffset(49, 129)]
		public bool GrenadeLauncher { get; set; }

		[FieldOffset(50, 130)]
		public bool StaticGadget { get; set; }

		[FieldOffset(51, 131)]
		public bool DynamicGadget1 { get; set; }

		[FieldOffset(52, 132)]
		public bool DynamicGadget2 { get; set; }

		[FieldOffset(53, 133)]
		public bool MeleeAttack { get; set; }

		[FieldOffset(54, 134)]
		public bool ThrowGrenade { get; set; }

		[FieldOffset(55, 135)]
		public bool SelectWeapon1 { get; set; }

		[FieldOffset(56, 136)]
		public bool SelectWeapon2 { get; set; }

		[FieldOffset(57, 137)]
		public bool SelectWeapon3 { get; set; }

		[FieldOffset(58, 138)]
		public bool SelectWeapon4 { get; set; }

		[FieldOffset(59, 139)]
		public bool SelectWeapon5 { get; set; }

		[FieldOffset(60, 140)]
		public bool SelectWeapon6 { get; set; }

		[FieldOffset(61, 141)]
		public bool SelectWeapon7 { get; set; }

		[FieldOffset(62, 142)]
		public bool SelectWeapon8 { get; set; }

		[FieldOffset(63, 143)]
		public bool SelectWeapon9 { get; set; }

		[FieldOffset(64, 144)]
		public bool CommoRose { get; set; }

		[FieldOffset(65, 145)]
		public bool CameraPitch { get; set; }

		[FieldOffset(66, 146)]
		public bool CameraYaw { get; set; }

		[FieldOffset(67, 147)]
		public bool ToggleLight { get; set; }

		[FieldOffset(68, 148)]
		public bool CycleFireMode { get; set; }
	}
}

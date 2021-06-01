namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WeaponTypeCameraOverride : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<CinebotModeData> TargetLockMode { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<EquipItemType> EquipItemType { get; set; }
	}
}

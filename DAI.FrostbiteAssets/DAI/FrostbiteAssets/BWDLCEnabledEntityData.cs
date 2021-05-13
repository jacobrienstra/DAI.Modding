using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWDLCEnabledEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int DLCPackage { get; set; }

		[FieldOffset(24, 104)]
		public bool DebugEventEnabled { get; set; }
	}
}

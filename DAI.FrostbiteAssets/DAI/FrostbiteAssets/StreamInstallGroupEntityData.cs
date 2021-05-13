using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StreamInstallGroupEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public string GroupName { get; set; }

		[FieldOffset(24, 112)]
		public bool WaitForInstall { get; set; }
	}
}

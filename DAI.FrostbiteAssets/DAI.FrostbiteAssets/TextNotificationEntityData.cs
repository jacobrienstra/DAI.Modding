using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TextNotificationEntityData : SubTitledNotificationEntityData
	{
		[FieldOffset(80, 224)]
		public Realm Realm { get; set; }

		[FieldOffset(84, 232)]
		public string TextDataID { get; set; }
	}
}

using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StatChangeListenerEntityData : StatChangeListenerEntityBaseData
	{
		[FieldOffset(24, 112)]
		public Realm Realm { get; set; }
	}
}

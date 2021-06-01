using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_Realm : BoolProvider
	{
		[FieldOffset(8, 32)]
		public Realm Realm { get; set; }
	}
}

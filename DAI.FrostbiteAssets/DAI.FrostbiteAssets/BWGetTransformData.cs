using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWGetTransformData : BWGetTransformBaseData
	{
		[FieldOffset(24, 104)]
		public Realm Realm { get; set; }
	}
}

using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EventChannel : LinkObject
	{
		[FieldOffset(0, 0)]
		public Realm Realm { get; set; }
	}
}

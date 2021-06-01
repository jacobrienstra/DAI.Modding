using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LogicReferenceObjectData : ReferenceObjectData
	{
		[FieldOffset(112, 240)]
		public SubRealm SubRealm { get; set; }
	}
}

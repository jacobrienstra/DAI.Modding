using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PlayerEntryComponentData : EntryComponentData
	{
		[FieldOffset(192, 304)]
		public Vec3 AnimationAccelerationMultiplier { get; set; }

		[FieldOffset(208, 320)]
		public string AntEntryID { get; set; }

		[FieldOffset(212, 328)]
		public AntEntryIdEnum AntEntryId { get; set; }

		[FieldOffset(216, 336)]
		public ExternalObject<Dummy> AntEntryEnumeration { get; set; }
	}
}

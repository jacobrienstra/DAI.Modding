using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PropertyCastEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public float FloatValue { get; set; }

		[FieldOffset(24, 104)]
		public int IntValue { get; set; }

		[FieldOffset(28, 112)]
		public string StringValue { get; set; }

		[FieldOffset(32, 120)]
		public bool BoolValue { get; set; }
	}
}

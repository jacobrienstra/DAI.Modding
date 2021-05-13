using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWServerTweakableValueEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public float DefaultFloatValue { get; set; }

		[FieldOffset(24, 104)]
		public int DefaultIntValue { get; set; }

		[FieldOffset(28, 112)]
		public ExternalObject<Dummy> Provider { get; set; }

		[FieldOffset(32, 120)]
		public bool DefaultBoolValue { get; set; }
	}
}

using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_CharacterSpeed : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider> Character { get; set; }

		[FieldOffset(12, 40)]
		public BoolProvider_CharacterSpeedType SpeedCheckType { get; set; }

		[FieldOffset(16, 48)]
		public ExternalObject<FloatProvider_Const> MinSpeed { get; set; }

		[FieldOffset(20, 56)]
		public ExternalObject<FloatProvider_Const> MaxSpeed { get; set; }

		[FieldOffset(24, 64)]
		public bool Absolute { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ConditionalVec3EntityData : ConditionalStateEntityData
	{
		[FieldOffset(32, 112)]
		public Vec3 ValueIfTrue { get; set; }

		[FieldOffset(48, 128)]
		public Vec3 ValueIfFalse { get; set; }
	}
}

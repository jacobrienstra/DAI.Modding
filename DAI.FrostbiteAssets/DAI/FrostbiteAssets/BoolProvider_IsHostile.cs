namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_IsHostile : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider> EntityA { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<EntityProvider_Caster> EntityB { get; set; }

		[FieldOffset(16, 48)]
		public bool ReturnIfInvalid { get; set; }
	}
}

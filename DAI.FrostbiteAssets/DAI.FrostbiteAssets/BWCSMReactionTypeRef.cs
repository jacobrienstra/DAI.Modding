namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMReactionTypeRef : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint ReactionNameHash { get; set; }

		[FieldOffset(4, 4)]
		public float DestructibleDamage { get; set; }
	}
}

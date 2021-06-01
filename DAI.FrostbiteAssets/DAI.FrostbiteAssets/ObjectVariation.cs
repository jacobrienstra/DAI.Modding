namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ObjectVariation : Asset
	{
		[FieldOffset(12, 72)]
		public uint NameHash { get; set; }
	}
}

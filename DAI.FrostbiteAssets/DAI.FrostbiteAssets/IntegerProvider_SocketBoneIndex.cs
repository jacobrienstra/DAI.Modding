namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IntegerProvider_SocketBoneIndex : IntegerProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider> Entity { get; set; }

		[FieldOffset(12, 40)]
		public int Socket { get; set; }
	}
}

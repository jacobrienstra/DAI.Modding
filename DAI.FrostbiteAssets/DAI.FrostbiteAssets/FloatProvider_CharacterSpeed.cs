namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_CharacterSpeed : FloatProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider_Self> Entity { get; set; }
	}
}

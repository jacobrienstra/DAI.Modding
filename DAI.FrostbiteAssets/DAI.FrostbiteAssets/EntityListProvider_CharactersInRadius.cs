namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntityListProvider_CharactersInRadius : EntityListProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<FloatProvider> Radius { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<TransformProvider_Self> Position { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AntEnumeration : DataContainer
	{
		[FieldOffset(8, 24)]
		public AntRef AntAsset { get; set; }

		[FieldOffset(28, 72)]
		public int Value { get; set; }
	}
}

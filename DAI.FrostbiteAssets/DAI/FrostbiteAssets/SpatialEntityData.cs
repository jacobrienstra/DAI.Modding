namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SpatialEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform Transform { get; set; }
	}
}

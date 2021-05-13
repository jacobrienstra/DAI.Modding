namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ClothInteractionComponentSpawnData : DataContainer
	{
		[FieldOffset(8, 24)]
		public bool ClothCollision { get; set; }
	}
}

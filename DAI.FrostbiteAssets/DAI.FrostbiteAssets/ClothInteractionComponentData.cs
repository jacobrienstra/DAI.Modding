namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ClothInteractionComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public bool ClothCollision { get; set; }
	}
}

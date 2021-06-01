namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScaleAllItemsData : EntityData
	{
		[FieldOffset(16, 96)]
		public int Level { get; set; }
	}
}

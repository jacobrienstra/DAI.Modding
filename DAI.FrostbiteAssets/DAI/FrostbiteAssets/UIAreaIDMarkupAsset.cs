namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIAreaIDMarkupAsset : UIStringMarkupAsset
	{
		[FieldOffset(16, 40)]
		public int AreaID { get; set; }

		[FieldOffset(20, 44)]
		public bool Not { get; set; }
	}
}

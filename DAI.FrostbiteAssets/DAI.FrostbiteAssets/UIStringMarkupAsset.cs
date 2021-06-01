namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIStringMarkupAsset : DataContainer
	{
		[FieldOffset(8, 24)]
		public string MarkupTag { get; set; }

		[FieldOffset(12, 32)]
		public bool RequiresClosingTag { get; set; }
	}
}

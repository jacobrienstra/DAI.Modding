namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PathCreationOptions : Asset
	{
		[FieldOffset(12, 72)]
		public bool performInitialNavProbe { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMapLevelDataComponent : SubWorldDataComponent
	{
		[FieldOffset(8, 24)]
		public ExternalObject<BWMapGroup> MapGroup { get; set; }
	}
}

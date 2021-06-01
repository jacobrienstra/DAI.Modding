namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpdateSizeData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public Vec2 Pivot { get; set; }
	}
}

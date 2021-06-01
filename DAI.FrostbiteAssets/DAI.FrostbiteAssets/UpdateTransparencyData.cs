namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpdateTransparencyData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float CullThreshold { get; set; }
	}
}

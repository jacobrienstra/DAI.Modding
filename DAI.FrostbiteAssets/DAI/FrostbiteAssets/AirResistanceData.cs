namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AirResistanceData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float DragFactor { get; set; }
	}
}

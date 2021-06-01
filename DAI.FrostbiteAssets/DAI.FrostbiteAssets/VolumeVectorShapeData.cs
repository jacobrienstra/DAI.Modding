namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class VolumeVectorShapeData : VectorShapeData
	{
		[FieldOffset(28, 112)]
		public float Height { get; set; }
	}
}

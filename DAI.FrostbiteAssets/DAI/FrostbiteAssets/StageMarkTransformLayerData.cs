namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StageMarkTransformLayerData : TransformLayerData
	{
		[FieldOffset(32, 144)]
		public uint MarkId { get; set; }
	}
}

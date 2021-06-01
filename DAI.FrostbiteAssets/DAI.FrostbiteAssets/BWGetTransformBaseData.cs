namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWGetTransformBaseData : EntityData
	{
		[FieldOffset(16, 96)]
		public int AttachPoint { get; set; }

		[FieldOffset(20, 100)]
		public bool UpdateEveryFrame { get; set; }
	}
}

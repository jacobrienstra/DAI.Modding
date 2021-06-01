namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CloseToPartner : CSMTransformProvider
	{
		[FieldOffset(8, 32)]
		public float DistanceToPartner { get; set; }
	}
}

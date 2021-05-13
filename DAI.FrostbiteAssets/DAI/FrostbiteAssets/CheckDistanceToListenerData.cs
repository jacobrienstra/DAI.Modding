namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CheckDistanceToListenerData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform Transform { get; set; }

		[FieldOffset(80, 160)]
		public float Radius { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StreamingGateEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public float Timeout { get; set; }
	}
}

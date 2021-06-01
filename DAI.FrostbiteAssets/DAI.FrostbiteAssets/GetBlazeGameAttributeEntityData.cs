namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GetBlazeGameAttributeEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public string AttributeName { get; set; }
	}
}

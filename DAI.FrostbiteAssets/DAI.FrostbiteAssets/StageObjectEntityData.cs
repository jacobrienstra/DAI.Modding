namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class StageObjectEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public ExternalObject<StageEntityData> Stage { get; set; }

		[FieldOffset(84, 184)]
		public uint ObjectLinkID { get; set; }
	}
}

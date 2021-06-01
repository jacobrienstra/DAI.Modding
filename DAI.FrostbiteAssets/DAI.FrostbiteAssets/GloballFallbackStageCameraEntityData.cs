namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GloballFallbackStageCameraEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<StageCameraEntityData> GlobalFallbackCamera { get; set; }
	}
}

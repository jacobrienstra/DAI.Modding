namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotStateLogicEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<CinebotModeData> Mode { get; set; }

		[FieldOffset(20, 104)]
		public float PriorityOverride { get; set; }

		[FieldOffset(24, 108)]
		public bool EnablePriorityOverride { get; set; }
	}
}

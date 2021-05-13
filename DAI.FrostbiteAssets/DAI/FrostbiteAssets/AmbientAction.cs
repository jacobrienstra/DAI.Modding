namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AmbientAction : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<CSMStateReference> CSMStateRef { get; set; }

		[FieldOffset(16, 80)]
		public PlotConditionReference Condition { get; set; }

		[FieldOffset(44, 160)]
		public float SetBackDistance { get; set; }

		[FieldOffset(48, 164)]
		public float AllowedStopDistance { get; set; }
	}
}

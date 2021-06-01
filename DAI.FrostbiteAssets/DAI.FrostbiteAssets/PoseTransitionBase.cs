namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PoseTransitionBase : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<PoseDefinition> TransitionTo { get; set; }
	}
}

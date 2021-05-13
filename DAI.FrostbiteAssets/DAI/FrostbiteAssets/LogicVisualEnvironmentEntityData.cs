namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LogicVisualEnvironmentEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<VisualEnvironmentBlueprint> VisualEnvironment { get; set; }

		[FieldOffset(20, 104)]
		public float Visibility { get; set; }
	}
}

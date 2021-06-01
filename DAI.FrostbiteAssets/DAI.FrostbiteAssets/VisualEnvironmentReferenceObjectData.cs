namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class VisualEnvironmentReferenceObjectData : LogicReferenceObjectData
	{
		[FieldOffset(128, 256)]
		public int Priority { get; set; }

		[FieldOffset(132, 260)]
		public bool OverrideVisibility { get; set; }

		[FieldOffset(133, 261)]
		public bool OwnedByLightingContextPad { get; set; }
	}
}

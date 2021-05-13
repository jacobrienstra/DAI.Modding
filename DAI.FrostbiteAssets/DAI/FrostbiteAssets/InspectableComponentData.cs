namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class InspectableComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public Vec3 FloatyOffset { get; set; }

		[FieldOffset(112, 192)]
		public LocalizedStringReference DisplayName { get; set; }

		[FieldOffset(116, 216)]
		public float InspectionRadius { get; set; }

		[FieldOffset(120, 224)]
		public string InspectableNameOverride { get; set; }

		[FieldOffset(124, 232)]
		public bool Enable { get; set; }
	}
}

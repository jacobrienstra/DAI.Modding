namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_Raycast : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<TransformProvider> Source { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<TransformProvider> Target { get; set; }

		[FieldOffset(36, 88)]
		public int StoredTransformSlot { get; set; }

		[FieldOffset(40, 92)]
		public bool DontCheckWater { get; set; }

		[FieldOffset(41, 93)]
		public bool DontCheckTerrain { get; set; }

		[FieldOffset(42, 94)]
		public bool DontCheckRagdoll { get; set; }

		[FieldOffset(43, 95)]
		public bool DontCheckCharacter { get; set; }
	}
}

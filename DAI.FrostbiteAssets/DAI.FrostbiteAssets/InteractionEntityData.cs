namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class InteractionEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public float UseWithinRadius { get; set; }

		[FieldOffset(84, 180)]
		public float UseWithinAngle { get; set; }

		[FieldOffset(88, 184)]
		public uint MaxUses { get; set; }

		[FieldOffset(92, 188)]
		public float DisplayWithinRadius { get; set; }

		[FieldOffset(96, 192)]
		public ExternalObject<Dummy> PreInteractionSoundEffect { get; set; }

		[FieldOffset(100, 200)]
		public bool TestIfOccluded { get; set; }

		[FieldOffset(101, 201)]
		public bool AllowInteractionViaRemoteEntry { get; set; }

		[FieldOffset(102, 202)]
		public bool UseDisplayWithinRadius { get; set; }

		[FieldOffset(103, 203)]
		public bool Enabled { get; set; }
	}
}

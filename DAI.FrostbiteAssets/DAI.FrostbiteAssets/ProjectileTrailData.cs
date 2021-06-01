namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProjectileTrailData : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<Dummy> TrailHead { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<Dummy> TrailTail { get; set; }

		[FieldOffset(8, 16)]
		public bool StopTrailEffectOnUnspawn { get; set; }

		[FieldOffset(9, 17)]
		public bool BeamLocationsForTrailEffect { get; set; }
	}
}

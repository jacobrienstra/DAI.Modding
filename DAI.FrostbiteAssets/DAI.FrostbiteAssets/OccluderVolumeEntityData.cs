namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class OccluderVolumeEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public float CoverageValue { get; set; }

		[FieldOffset(84, 180)]
		public bool OccluderHighPriority { get; set; }

		[FieldOffset(85, 181)]
		public bool OccluderIsConservative { get; set; }

		[FieldOffset(86, 182)]
		public bool Visible { get; set; }

		[FieldOffset(87, 183)]
		public bool OccludesLight { get; set; }
	}
}

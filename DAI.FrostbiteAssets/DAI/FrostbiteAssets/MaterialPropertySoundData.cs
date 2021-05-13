namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialPropertySoundData : PhysicsMaterialRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public ExternalObject<Dummy> ImpactSound { get; set; }

		[FieldOffset(12, 48)]
		public ExternalObject<Dummy> ScrapeSound { get; set; }

		[FieldOffset(16, 56)]
		public float ScrapeLength { get; set; }

		[FieldOffset(20, 64)]
		public ExternalObject<Dummy> SoldierSettings { get; set; }

		[FieldOffset(24, 72)]
		public float Softness { get; set; }

		[FieldOffset(28, 76)]
		public float MaterialSoundId { get; set; }

		[FieldOffset(32, 80)]
		public float Absorption { get; set; }
	}
}

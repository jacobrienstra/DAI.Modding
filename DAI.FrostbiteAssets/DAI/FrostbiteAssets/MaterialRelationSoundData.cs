namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialRelationSoundData : PhysicsMaterialRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public ExternalObject<SoundPatchConfigurationAsset> ImpactSound { get; set; }

		[FieldOffset(12, 48)]
		public ExternalObject<AudioGraphEvent> ImpactSoundEvent { get; set; }

		[FieldOffset(16, 56)]
		public ExternalObject<Dummy> ScrapeSound { get; set; }

		[FieldOffset(20, 64)]
		public float ScrapeLength { get; set; }
	}
}

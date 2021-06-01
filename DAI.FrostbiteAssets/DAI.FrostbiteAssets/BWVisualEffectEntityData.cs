namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWVisualEffectEntityData : GameComponentEntityData
	{
		[FieldOffset(112, 208)]
		public ExternalObject<EffectBlueprint> VisualEffect { get; set; }

		[FieldOffset(116, 216)]
		public ExternalObject<SpatialPrefabBlueprint> VisualEffectPrefab { get; set; }
	}
}

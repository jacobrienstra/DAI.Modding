namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CreatureFootplantEffectComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public MaterialDecl FootMaterialPair { get; set; }

		[FieldOffset(100, 192)]
		public float HeightOverGroundThreshold { get; set; }

		[FieldOffset(104, 200)]
		public AntRef FootPlantingPointerAsset { get; set; }

		[FieldOffset(124, 248)]
		public float LodDistance { get; set; }

		[FieldOffset(128, 252)]
		public bool IsQuadruped { get; set; }
	}
}

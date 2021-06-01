namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ClothEntityData : GameComponentEntityData
	{
		[FieldOffset(112, 208)]
		public ExternalObject<MeshAsset> Mesh { get; set; }

		[FieldOffset(116, 216)]
		public ExternalObject<ClothAsset> Cloth { get; set; }

		[FieldOffset(120, 224)]
		public bool CharacterLightingEnable { get; set; }
	}
}

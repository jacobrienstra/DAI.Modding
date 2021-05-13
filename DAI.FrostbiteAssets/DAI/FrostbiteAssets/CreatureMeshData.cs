namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureMeshData : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<Dummy> Mesh { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<Dummy> MeshBlueprint { get; set; }

		[FieldOffset(8, 16)]
		public int RandomGroup { get; set; }
	}
}

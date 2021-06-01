using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialGridData : Asset
	{
		[FieldOffset(12, 72)]
		public MaterialDecl DefaultMaterial { get; set; }

		[FieldOffset(16, 88)]
		public List<MaterialDecl> MaterialPairs { get; set; }

		[FieldOffset(20, 96)]
		public List<uint> MaterialIndexMap { get; set; }

		[FieldOffset(24, 104)]
		public uint DefaultMaterialIndex { get; set; }

		[FieldOffset(28, 112)]
		public List<MaterialRelationPropertyPair> MaterialProperties { get; set; }

		[FieldOffset(32, 120)]
		public List<MaterialInteractionGridRow> InteractionGrid { get; set; }

		public MaterialGridData()
		{
			MaterialPairs = new List<MaterialDecl>();
			MaterialIndexMap = new List<uint>();
			MaterialProperties = new List<MaterialRelationPropertyPair>();
			InteractionGrid = new List<MaterialInteractionGridRow>();
		}
	}
}

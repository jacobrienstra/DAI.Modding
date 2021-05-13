using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SimpleEquipmentMeshesEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public List<MeshSocketPair> Meshes { get; set; }

		public SimpleEquipmentMeshesEntityData()
		{
			Meshes = new List<MeshSocketPair>();
		}
	}
}

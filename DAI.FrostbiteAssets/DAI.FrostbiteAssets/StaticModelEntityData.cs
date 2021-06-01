using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class StaticModelEntityData : GamePhysicsEntityData
	{
		[FieldOffset(128, 240)]
		public List<ExternalObject<Dummy>> PartLinks { get; set; }

		[FieldOffset(132, 248)]
		public ExternalObject<MeshAsset> Mesh { get; set; }

		[FieldOffset(136, 256)]
		public uint BoneCount { get; set; }

		[FieldOffset(140, 264)]
		public List<LinearTransform> BasePoseTransforms { get; set; }

		[FieldOffset(144, 272)]
		public List<PhysicsPartInfo> PhysicsPartInfos { get; set; }

		[FieldOffset(148, 280)]
		public StaticModelNetworkInfo NetworkInfo { get; set; }

		[FieldOffset(164, 312)]
		public List<uint> DestructiblePartIds { get; set; }

		[FieldOffset(168, 320)]
		public bool ExcludeFromNearbyObjectDestruction { get; set; }

		[FieldOffset(169, 321)]
		public bool AnimatePhysics { get; set; }

		[FieldOffset(170, 322)]
		public bool TerrainShaderNodesEnable { get; set; }

		[FieldOffset(171, 323)]
		public bool Visible { get; set; }

		public StaticModelEntityData()
		{
			PartLinks = new List<ExternalObject<Dummy>>();
			BasePoseTransforms = new List<LinearTransform>();
			PhysicsPartInfos = new List<PhysicsPartInfo>();
			DestructiblePartIds = new List<uint>();
		}
	}
}

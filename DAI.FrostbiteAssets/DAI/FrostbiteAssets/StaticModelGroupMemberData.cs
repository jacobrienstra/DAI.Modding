using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StaticModelGroupMemberData : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<LinearTransform> InstanceTransforms { get; set; }

		[FieldOffset(4, 8)]
		public List<uint> InstanceObjectVariation { get; set; }

		[FieldOffset(8, 16)]
		public List<bool> InstanceCastSunShadow { get; set; }

		[FieldOffset(12, 24)]
		public List<bool> InstanceCastReflection { get; set; }

		[FieldOffset(16, 32)]
		public List<uint> DestructiblePartIds { get; set; }

		[FieldOffset(20, 40)]
		public List<ExternalObject<StaticModelGroupEntityData>> InstanceShaderParams { get; set; }

		[FieldOffset(24, 48)]
		public List<RadiosityTypeOverride> InstanceRadiosityTypeOverride { get; set; }

		[FieldOffset(28, 56)]
		public List<Dummy> InstanceEnabled { get; set; }

		[FieldOffset(32, 64)]
		public List<bool> InstanceTerrainShaderNodesEnable { get; set; }

		[FieldOffset(36, 72)]
		public ExternalObject<StaticModelEntityData> MemberType { get; set; }

		[FieldOffset(40, 80)]
		public ExternalObject<MeshAsset> MeshAsset { get; set; }

		[FieldOffset(44, 88)]
		public List<bool> InstanceIsOccluder { get; set; }

		[FieldOffset(48, 96)]
		public uint InstanceCount { get; set; }

		[FieldOffset(52, 100)]
		public uint HealthStateEntityManagerId { get; set; }

		[FieldOffset(56, 104)]
		public IndexRange PhysicsPartRange { get; set; }

		[FieldOffset(64, 112)]
		public uint PhysicsPartCountPerInstance { get; set; }

		[FieldOffset(68, 116)]
		public IndexRange NetworkIdRange { get; set; }

		[FieldOffset(76, 124)]
		public uint NetworkIdCountPerInstance { get; set; }

		[FieldOffset(80, 128)]
		public uint PartComponentCount { get; set; }

		public StaticModelGroupMemberData()
		{
			InstanceTransforms = new List<LinearTransform>();
			InstanceObjectVariation = new List<uint>();
			InstanceCastSunShadow = new List<bool>();
			InstanceCastReflection = new List<bool>();
			DestructiblePartIds = new List<uint>();
			InstanceShaderParams = new List<ExternalObject<StaticModelGroupEntityData>>();
			InstanceRadiosityTypeOverride = new List<RadiosityTypeOverride>();
			InstanceEnabled = new List<Dummy>();
			InstanceTerrainShaderNodesEnable = new List<bool>();
			InstanceIsOccluder = new List<bool>();
		}
	}
}

using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWRayCastEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public Realm Realm { get; set; }

		[FieldOffset(84, 180)]
		public float RayOffset { get; set; }

		[FieldOffset(88, 184)]
		public float RayLength { get; set; }

		[FieldOffset(92, 188)]
		public BWRayEndTransformOrientation EndTransformOrientation { get; set; }

		[FieldOffset(96, 192)]
		public bool CheckDetailed { get; set; }

		[FieldOffset(97, 193)]
		public bool DontCheckWater { get; set; }

		[FieldOffset(98, 194)]
		public bool DontCheckTerrain { get; set; }

		[FieldOffset(99, 195)]
		public bool DontCheckRagdoll { get; set; }

		[FieldOffset(100, 196)]
		public bool DontCheckCharacter { get; set; }

		[FieldOffset(101, 197)]
		public bool DontCheckPenetrable { get; set; }

		[FieldOffset(102, 198)]
		public bool DontCheckClientDestructible { get; set; }

		[FieldOffset(103, 199)]
		public bool DontCheckSeeThrough { get; set; }

		[FieldOffset(104, 200)]
		public bool DontCheckNoCollisionResponse { get; set; }

		[FieldOffset(105, 201)]
		public bool DontCheckNoCollisionResponseCombined { get; set; }
	}
}

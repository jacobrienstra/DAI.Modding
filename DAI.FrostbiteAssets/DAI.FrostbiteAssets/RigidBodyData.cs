using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class RigidBodyData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec3 InertiaModifier { get; set; }

		[FieldOffset(32, 112)]
		public LinearTransform Transform { get; set; }

		[FieldOffset(96, 176)]
		public LinearTransform KeyframeTransform { get; set; }

		[FieldOffset(160, 240)]
		public RigidBodyType RigidBodyType { get; set; }

		[FieldOffset(164, 244)]
		public float Mass { get; set; }

		[FieldOffset(168, 248)]
		public float Friction { get; set; }

		[FieldOffset(172, 252)]
		public float Restitution { get; set; }

		[FieldOffset(176, 256)]
		public float AngularVelocityDamping { get; set; }

		[FieldOffset(180, 260)]
		public float LinearVelocityDamping { get; set; }

		[FieldOffset(184, 264)]
		public uint InteractionToolkitCollisionVolumeId { get; set; }

		[FieldOffset(188, 268)]
		public RigidBodyMotionType MotionType { get; set; }

		[FieldOffset(192, 272)]
		public RigidBodyQualityType QualityType { get; set; }

		[FieldOffset(196, 276)]
		public RigidBodyCollisionLayer CollisionLayer { get; set; }

		[FieldOffset(200, 280)]
		public List<uint> PartIndices { get; set; }

		[FieldOffset(204, 288)]
		public ExternalObject<BoxFloatPhysicsData> FloatPhysics { get; set; }

		[FieldOffset(208, 296)]
		public bool IsRootController { get; set; }

		public RigidBodyData()
		{
			PartIndices = new List<uint>();
		}
	}
}

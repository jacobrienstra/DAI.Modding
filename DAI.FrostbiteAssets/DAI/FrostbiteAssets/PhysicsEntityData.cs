using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PhysicsEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec3 InertiaModifier { get; set; }

		[FieldOffset(32, 112)]
		public ExternalObject<HavokAsset> Asset { get; set; }

		[FieldOffset(36, 120)]
		public List<ExternalObject<DataContainer>> RigidBodies { get; set; }

		[FieldOffset(40, 128)]
		public ExternalObject<Dummy> FloatPhysics { get; set; }

		[FieldOffset(44, 136)]
		public float Mass { get; set; }

		[FieldOffset(48, 140)]
		public float Friction { get; set; }

		[FieldOffset(52, 144)]
		public float Restitution { get; set; }

		[FieldOffset(56, 148)]
		public float AngularVelocityDamping { get; set; }

		[FieldOffset(60, 152)]
		public float LinearVelocityDamping { get; set; }

		[FieldOffset(64, 160)]
		public ExternalObject<Dummy> Proximity { get; set; }

		[FieldOffset(68, 168)]
		public List<ExternalObject<Dummy>> Constraints { get; set; }

		[FieldOffset(72, 176)]
		public bool MovableParts { get; set; }

		[FieldOffset(73, 177)]
		public bool IsComposite { get; set; }

		public PhysicsEntityData()
		{
			RigidBodies = new List<ExternalObject<DataContainer>>();
			Constraints = new List<ExternalObject<Dummy>>();
		}
	}
}

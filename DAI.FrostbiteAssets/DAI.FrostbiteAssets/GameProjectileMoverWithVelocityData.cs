using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class GameProjectileMoverWithVelocityData : GameProjectileMoverData
	{
		[FieldOffset(52, 96)]
		public float InitialSpeed { get; set; }

		[FieldOffset(56, 100)]
		public float Gravity { get; set; }

		[FieldOffset(60, 104)]
		public float CollisionAbsorbPercent { get; set; }

		[FieldOffset(64, 112)]
		public Vec4 VelocityEnvelope { get; set; }

		[FieldOffset(80, 128)]
		public Vec3 PostCollisionGravity { get; set; }

		[FieldOffset(96, 144)]
		public float StaticCollisionSlide { get; set; }

		[FieldOffset(100, 148)]
		public float StaticCollisionBounce { get; set; }

		[FieldOffset(104, 152)]
		public int MaxWorldBounces { get; set; }

		[FieldOffset(108, 160)]
		public List<ExternalObject<BWCSMAction>> ModifierData { get; set; }

		[FieldOffset(112, 168)]
		public bool StaticCollisionDeflection { get; set; }

		[FieldOffset(113, 169)]
		public bool ReNormalizeModifierMotion { get; set; }

		public GameProjectileMoverWithVelocityData()
		{
			ModifierData = new List<ExternalObject<BWCSMAction>>();
		}
	}
}

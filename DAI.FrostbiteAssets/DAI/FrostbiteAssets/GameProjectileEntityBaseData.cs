using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class GameProjectileEntityBaseData : GamePhysicsEntityData
	{
		[FieldOffset(128, 240)]
		public ReplicationType ReplicationType { get; set; }

		[FieldOffset(132, 248)]
		public MaterialDecl MaterialPair { get; set; }

		[FieldOffset(136, 264)]
		public ExternalObject<EffectBlueprint> TrailEffect { get; set; }

		[FieldOffset(140, 272)]
		public ProjectileTrailData TrailData { get; set; }

		[FieldOffset(152, 296)]
		public float TimeToLive { get; set; }

		[FieldOffset(156, 304)]
		public ExternalObject<GameProjectileMoverWithVelocityData> MoverData { get; set; }

		[FieldOffset(160, 312)]
		public List<ExternalObject<Dummy>> Detonators { get; set; }

		[FieldOffset(164, 320)]
		public ExternalObject<EffectBlueprint> CollisionReflectEffect { get; set; }

		[FieldOffset(168, 328)]
		public ExternalObject<EffectBlueprint> CollisionAbsorbEffect { get; set; }

		[FieldOffset(172, 336)]
		public float VisualConvergeDistance { get; set; }

		[FieldOffset(176, 340)]
		public float VisualConvergenceDelay { get; set; }

		[FieldOffset(180, 344)]
		public float VisualConvergenceDuration { get; set; }

		[FieldOffset(184, 348)]
		public bool FaceVelocityDirection { get; set; }

		[FieldOffset(185, 349)]
		public bool RotateToOutsideOfCurve { get; set; }

		public GameProjectileEntityBaseData()
		{
			Detonators = new List<ExternalObject<Dummy>>();
		}
	}
}

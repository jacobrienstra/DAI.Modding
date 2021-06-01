using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialRelationEffectData : PhysicsMaterialRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public List<EffectWithSpeedRange> ImpactEffects { get; set; }

		[FieldOffset(12, 48)]
		public List<ExternalObject<Dummy>> ImpactDebris { get; set; }

		[FieldOffset(16, 56)]
		public float ImpactEffectMaxSpreadAngle { get; set; }

		[FieldOffset(20, 60)]
		public bool MirrorImpactDirection { get; set; }

		[FieldOffset(21, 61)]
		public bool EnableInheritedVelocity { get; set; }

		public MaterialRelationEffectData()
		{
			ImpactEffects = new List<EffectWithSpeedRange>();
			ImpactDebris = new List<ExternalObject<Dummy>>();
		}
	}
}

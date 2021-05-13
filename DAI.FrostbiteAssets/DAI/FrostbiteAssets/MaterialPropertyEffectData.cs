using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialPropertyEffectData : PhysicsMaterialRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public List<EffectWithSpeedRange> ImpactEffects { get; set; }

		public MaterialPropertyEffectData()
		{
			ImpactEffects = new List<EffectWithSpeedRange>();
		}
	}
}

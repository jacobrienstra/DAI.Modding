using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EffectEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public List<ExternalObject<EffectEntityData>> Components { get; set; }

		[FieldOffset(84, 184)]
		public QualityScalableInt MaxActiveInstanceCount { get; set; }

		[FieldOffset(100, 200)]
		public QualityScalableFloat CullDistance { get; set; }

		[FieldOffset(116, 216)]
		public float StartDelay { get; set; }

		[FieldOffset(120, 220)]
		public bool ResetInstanceWhenStarted { get; set; }

		[FieldOffset(121, 221)]
		public bool AttachToSpawnSurface { get; set; }

		[FieldOffset(122, 222)]
		public QualityScalableBool Enable { get; set; }

		[FieldOffset(126, 226)]
		public bool OverrideDrawOrder { get; set; }

		public EffectEntityData()
		{
			Components = new List<ExternalObject<EffectEntityData>>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EffectComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<EffectBlueprint> Effect { get; set; }

		[FieldOffset(100, 184)]
		public float EmitterParameter1 { get; set; }

		[FieldOffset(104, 188)]
		public float EmitterParameter2 { get; set; }

		[FieldOffset(108, 192)]
		public float EmitterParameter3 { get; set; }

		[FieldOffset(112, 196)]
		public float OverrideHeight { get; set; }

		[FieldOffset(116, 200)]
		public int MaxInstances { get; set; }

		[FieldOffset(120, 208)]
		public List<ExternalObject<PartComponentData>> EffectParameters { get; set; }

		[FieldOffset(124, 216)]
		public bool AutoStart { get; set; }

		[FieldOffset(125, 217)]
		public bool SnapToWaterSurface { get; set; }

		public EffectComponentData()
		{
			EffectParameters = new List<ExternalObject<PartComponentData>>();
		}
	}
}

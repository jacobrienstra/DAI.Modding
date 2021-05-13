using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TiledVisualEffectEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform StartTransform { get; set; }

		[FieldOffset(80, 160)]
		public LinearTransform EndTransform { get; set; }

		[FieldOffset(144, 224)]
		public ExternalObject<TransformProvider> StartPoint { get; set; }

		[FieldOffset(148, 232)]
		public ExternalObject<TransformProvider> EndPoint { get; set; }

		[FieldOffset(152, 240)]
		public float TileLength { get; set; }

		[FieldOffset(156, 244)]
		public DynamicTilingGapMode GapMode { get; set; }

		[FieldOffset(160, 248)]
		public ExternalObject<EffectBlueprint> LoopEffect { get; set; }

		[FieldOffset(164, 256)]
		public List<SinWave> Waves { get; set; }

		[FieldOffset(168, 264)]
		public TimeDeltaType TimeDeltaType { get; set; }

		public TiledVisualEffectEntityData()
		{
			Waves = new List<SinWave>();
		}
	}
}

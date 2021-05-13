using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundPatchAsset : SoundGraphAsset
	{
		[FieldOffset(28, 104)]
		public List<ExternalObject<OutputNodeData>> OutputNodes { get; set; }

		[FieldOffset(32, 112)]
		public float Loudness { get; set; }

		[FieldOffset(36, 116)]
		public float AILoudness { get; set; }

		[FieldOffset(40, 120)]
		public float Radius { get; set; }

		[FieldOffset(44, 124)]
		public float DopplerFactor { get; set; }

		[FieldOffset(48, 128)]
		public float MasterPitch { get; set; }

		[FieldOffset(52, 136)]
		public ExternalObject<AudioGraphEvent> DefaultStartEvent { get; set; }

		[FieldOffset(56, 144)]
		public ExternalObject<AudioGraphEvent> DefaultStopEvent { get; set; }

		[FieldOffset(60, 152)]
		public ExternalObject<AudioGraphEvent> DefaultEnterScopeEvent { get; set; }

		[FieldOffset(64, 160)]
		public ExternalObject<AudioGraphEvent> DefaultForceInitEvent { get; set; }

		[FieldOffset(68, 168)]
		public QualityScalableFloat MaxDistance { get; set; }

		[FieldOffset(84, 184)]
		public bool IsLooping { get; set; }

		[FieldOffset(85, 185)]
		public bool IsPersistent { get; set; }

		public SoundPatchAsset()
		{
			OutputNodes = new List<ExternalObject<OutputNodeData>>();
		}
	}
}

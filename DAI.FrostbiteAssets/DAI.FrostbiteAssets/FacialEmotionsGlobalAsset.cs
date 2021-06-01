using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FacialEmotionsGlobalAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public AntRef OverallWeightGameState { get; set; }

		[FieldOffset(32, 120)]
		public List<ExternalObject<FacialEmotionLayerDefinition>> EmotionLayers { get; set; }

		[FieldOffset(36, 128)]
		public List<ExternalObject<FacialEmotionLayerDefinition>> Presets { get; set; }

		public FacialEmotionsGlobalAsset()
		{
			EmotionLayers = new List<ExternalObject<FacialEmotionLayerDefinition>>();
			Presets = new List<ExternalObject<FacialEmotionLayerDefinition>>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FacialEmotionTrackData : LinkTrackData
	{
		[FieldOffset(32, 144)]
		public ExternalObject<FacialEmotionsGlobalAsset> FacialEmotionsAsset { get; set; }

		[FieldOffset(36, 152)]
		public List<ExternalObject<EntityData>> Keyframes { get; set; }

		public FacialEmotionTrackData()
		{
			Keyframes = new List<ExternalObject<EntityData>>();
		}
	}
}

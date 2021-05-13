using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ClientTextFloatyManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<TextFloatySetting> TextFloatySettings { get; set; }

		[FieldOffset(20, 104)]
		public float OverlapDelaySec { get; set; }

		[FieldOffset(24, 108)]
		public float CutoffDistance { get; set; }

		public ClientTextFloatyManagerEntityData()
		{
			TextFloatySettings = new List<TextFloatySetting>();
		}
	}
}

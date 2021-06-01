using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIComponentData : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public string ShortName { get; set; }

		[FieldOffset(16, 80)]
		public List<string> DataSources { get; set; }

		[FieldOffset(20, 88)]
		public int UpdatesPerSecond { get; set; }

		[FieldOffset(24, 92)]
		public UIUpdateType UpdateType { get; set; }

		[FieldOffset(28, 96)]
		public uint MaxAllowedSkipFrames { get; set; }

		public UIComponentData()
		{
			DataSources = new List<string>();
		}
	}
}

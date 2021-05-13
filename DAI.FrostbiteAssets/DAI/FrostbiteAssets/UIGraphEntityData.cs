using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIGraphEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<EventSpec> Events { get; set; }

		[FieldOffset(20, 104)]
		public ExternalObject<UIGraphAsset> GraphAsset { get; set; }

		[FieldOffset(24, 112)]
		public UIGraphPriority GraphPriority { get; set; }

		[FieldOffset(28, 116)]
		public UIState State { get; set; }

		[FieldOffset(32, 120)]
		public bool PopPreviousGraph { get; set; }

		public UIGraphEntityData()
		{
			Events = new List<EventSpec>();
		}
	}
}

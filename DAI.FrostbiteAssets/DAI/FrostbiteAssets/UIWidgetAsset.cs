using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class UIWidgetAsset : UIAsset
	{
		[FieldOffset(24, 128)]
		public List<WidgetEventQueryPair> WidgetEvents { get; set; }

		public UIWidgetAsset()
		{
			WidgetEvents = new List<WidgetEventQueryPair>();
		}
	}
}

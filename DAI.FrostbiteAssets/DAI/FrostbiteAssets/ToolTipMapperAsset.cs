using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ToolTipMapperAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<ToolTipEntry>> ToolTipSymbols { get; set; }

		public ToolTipMapperAsset()
		{
			ToolTipSymbols = new List<ExternalObject<ToolTipEntry>>();
		}
	}
}

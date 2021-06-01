using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIElementInclusionSettings : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<Dummy> CustomInclusionCritera { get; set; }

		[FieldOffset(4, 8)]
		public bool IsSingleplayerLayer { get; set; }

		[FieldOffset(5, 9)]
		public bool IsMultiplayerLayer { get; set; }

		[FieldOffset(6, 10)]
		public bool IsSDLayer { get; set; }

		[FieldOffset(7, 11)]
		public bool IsHDLayer { get; set; }

		public UIElementInclusionSettings()
		{
			CustomInclusionCritera = new List<Dummy>();
		}
	}
}

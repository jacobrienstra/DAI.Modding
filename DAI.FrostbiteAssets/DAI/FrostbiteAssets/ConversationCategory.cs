using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationCategory : DataContainer
	{
		[FieldOffset(8, 24)]
		public ConversationChooserPosition Position { get; set; }

		[FieldOffset(12, 32)]
		public string IconPath { get; set; }

		[FieldOffset(16, 40)]
		public ExternalObject<Dummy> SubChooserType { get; set; }

		[FieldOffset(20, 48)]
		public List<ExternalObject<ConversationChooserType>> ValidChooserTypes { get; set; }

		[FieldOffset(24, 56)]
		public PlotActionReference OnCategorySelectedAction { get; set; }

		[FieldOffset(48, 128)]
		public bool AllowMultiples { get; set; }

		[FieldOffset(49, 129)]
		public bool IconFilterOption { get; set; }

		public ConversationCategory()
		{
			ValidChooserTypes = new List<ExternalObject<ConversationChooserType>>();
		}
	}
}

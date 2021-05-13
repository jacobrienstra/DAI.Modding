using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ChooserAutomaticPositionList : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<ConversationChooserPosition> AutomaticPositions { get; set; }

		public ChooserAutomaticPositionList()
		{
			AutomaticPositions = new List<ConversationChooserPosition>();
		}
	}
}

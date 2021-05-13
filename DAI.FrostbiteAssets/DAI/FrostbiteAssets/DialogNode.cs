using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DialogNode : StateNode
	{
		[FieldOffset(64, 136)]
		public string DialogTitle { get; set; }

		[FieldOffset(68, 144)]
		public string DialogText { get; set; }

		[FieldOffset(72, 152)]
		public List<UIPopupButton> Buttons { get; set; }

		public DialogNode()
		{
			Buttons = new List<UIPopupButton>();
		}
	}
}

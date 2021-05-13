using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIButtonLegendIDMapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public UIButtonLegendButtonID ButtonID { get; set; }

		[FieldOffset(4, 8)]
		public List<InputDevicePadButtons> Buttons { get; set; }

		[FieldOffset(8, 16)]
		public List<InputDeviceAxes> Axes { get; set; }

		public UIButtonLegendIDMapping()
		{
			Buttons = new List<InputDevicePadButtons>();
			Axes = new List<InputDeviceAxes>();
		}
	}
}

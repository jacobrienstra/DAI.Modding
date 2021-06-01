using System;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SendGUIMessage : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public BWGUIMessageType GUIMessageType { get; set; }

		[FieldOffset(32, 76)]
		public Guid AbilityGuid { get; set; }
	}
}

using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InputActionMapData : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<ExternalObject<EntryInputActionMapData>> Actions { get; set; }

		[FieldOffset(12, 32)]
		public InputActionMapPlatform PlatformSpecific { get; set; }

		[FieldOffset(16, 36)]
		public InputActionMapSlot Slot { get; set; }

		[FieldOffset(20, 40)]
		public string CopyKeyBindingsFrom { get; set; }

		public InputActionMapData()
		{
			Actions = new List<ExternalObject<EntryInputActionMapData>>();
		}
	}
}

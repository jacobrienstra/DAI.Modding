using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntryInputActionMapsData : Asset
	{
		[FieldOffset(12, 72)]
		public int ActionMapSettingsScheme { get; set; }

		[FieldOffset(16, 76)]
		public InputActionMapSlot DefaultInputActionMap { get; set; }

		[FieldOffset(20, 80)]
		public List<ExternalObject<EntryInputActionMapData>> InputActionMaps { get; set; }

		public EntryInputActionMapsData()
		{
			InputActionMaps = new List<ExternalObject<EntryInputActionMapData>>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntryInputActionBindingsData : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<EntryInputActionBinding> Bindings { get; set; }

		public EntryInputActionBindingsData()
		{
			Bindings = new List<EntryInputActionBinding>();
		}
	}
}

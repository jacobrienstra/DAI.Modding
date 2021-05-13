using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWInteractionMap : SystemSettings
	{
		[FieldOffset(16, 40)]
		public List<BWInteractionData> InteractionData { get; set; }

		public BWInteractionMap()
		{
			InteractionData = new List<BWInteractionData>();
		}
	}
}

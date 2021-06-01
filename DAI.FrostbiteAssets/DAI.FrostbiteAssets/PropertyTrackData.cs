using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PropertyTrackData : DataContainer
	{
		[FieldOffset(8, 24)]
		public new int Id { get; set; }

		[FieldOffset(12, 32)]
		public List<int> Times { get; set; }

		public PropertyTrackData()
		{
			Times = new List<int>();
		}
	}
}

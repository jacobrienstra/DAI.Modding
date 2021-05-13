using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LevelDescription : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Name { get; set; }

		[FieldOffset(4, 8)]
		public string Description { get; set; }

		[FieldOffset(8, 16)]
		public List<ExternalObject<DataContainer>> Components { get; set; }

		[FieldOffset(12, 24)]
		public bool IsMultiplayer { get; set; }

		[FieldOffset(13, 25)]
		public bool IsCoop { get; set; }

		[FieldOffset(14, 26)]
		public bool IsMenu { get; set; }

		[FieldOffset(15, 27)]
		public bool IsEpilogue { get; set; }

		public LevelDescription()
		{
			Components = new List<ExternalObject<DataContainer>>();
		}
	}
}

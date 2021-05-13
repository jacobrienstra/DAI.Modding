using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WorldStateSet : DataContainer
	{
		[FieldOffset(8, 24)]
		public string SetName { get; set; }

		[FieldOffset(12, 32)]
		public string CanonHashValue { get; set; }

		[FieldOffset(16, 40)]
		public string UploadSetName { get; set; }

		[FieldOffset(20, 48)]
		public List<ExternalObject<BWWorldStateConfig>> Variables { get; set; }

		[FieldOffset(24, 56)]
		public List<ExternalObject<BWWorldStateConfig>> Descriptions { get; set; }

		public WorldStateSet()
		{
			Variables = new List<ExternalObject<BWWorldStateConfig>>();
			Descriptions = new List<ExternalObject<BWWorldStateConfig>>();
		}
	}
}

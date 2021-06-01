using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ClothComponentSpawnData : ExtraSpawnData
	{
		[FieldOffset(8, 24)]
		public List<ExternalObject<Asset>> Instances { get; set; }

		[FieldOffset(12, 32)]
		public bool Enabled { get; set; }

		[FieldOffset(13, 33)]
		public bool OverrideInstances { get; set; }

		public ClothComponentSpawnData()
		{
			Instances = new List<ExternalObject<Asset>>();
		}
	}
}

using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class AlternateSpawnEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public TeamId Team { get; set; }

		[FieldOffset(84, 180)]
		public bool Enabled { get; set; }
	}
}

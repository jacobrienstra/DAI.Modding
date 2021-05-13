namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AmbientLocatorBlockerAreaData : EntityData
	{
		[FieldOffset(16, 96)]
		public float DisableRadius { get; set; }

		[FieldOffset(20, 100)]
		public bool Enabled { get; set; }
	}
}

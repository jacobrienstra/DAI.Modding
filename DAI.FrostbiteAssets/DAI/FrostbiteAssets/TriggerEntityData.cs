namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TriggerEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public float Delay { get; set; }

		[FieldOffset(84, 180)]
		public bool RunOnce { get; set; }

		[FieldOffset(85, 181)]
		public bool Enabled { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ZoneStreamerFocalPointEntityData : ZoneStreamerLogicEntityData
	{
		[FieldOffset(20, 104)]
		public bool Enabled { get; set; }
	}
}

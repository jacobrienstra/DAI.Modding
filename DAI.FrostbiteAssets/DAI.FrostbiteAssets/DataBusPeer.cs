namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DataBusPeer : GameDataContainer
	{
		[FieldOffset(8, 24)]
		public uint Flags { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AntGameStateData : DataContainer
	{
		[FieldOffset(8, 24)]
		public int PropertyHash { get; set; }
	}
}

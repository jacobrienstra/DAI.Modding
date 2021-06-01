namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWSaveGameEntityProxyData : EntityData
	{
		[FieldOffset(16, 96)]
		public bool Stack { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameObjectData : DataBusPeer
	{
		[FieldOffset(12, 32)]
		public uint StableSaveId { get; set; }
	}
}

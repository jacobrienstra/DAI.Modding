namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3DoorControllerData : EntityData
	{
		[FieldOffset(16, 96)]
		public bool Bashable { get; set; }
	}
}

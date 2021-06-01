namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SimpleEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public bool Enabled { get; set; }
	}
}

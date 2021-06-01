namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ObjectBlueprint : Blueprint
	{
		[FieldOffset(32, 176)]
		public ExternalObject<EntityData> Object { get; set; }
	}
}

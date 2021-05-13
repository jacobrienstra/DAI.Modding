namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureClassFilterEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<CreatureClass> ClassToCheck { get; set; }

		[FieldOffset(4, 8)]
		public bool OnTrue { get; set; }
	}
}

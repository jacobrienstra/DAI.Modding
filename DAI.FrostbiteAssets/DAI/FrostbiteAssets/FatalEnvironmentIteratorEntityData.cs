namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FatalEnvironmentIteratorEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public bool Blocked { get; set; }
	}
}

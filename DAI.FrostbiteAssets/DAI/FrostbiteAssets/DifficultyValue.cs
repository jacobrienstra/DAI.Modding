namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DifficultyValue : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public int Hash { get; set; }
	}
}

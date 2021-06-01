namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class AIUseableStaticTargetComponentData : BWStaticTargetComponentData
	{
		[FieldOffset(128, 224)]
		public int UseablePropType { get; set; }
	}
}

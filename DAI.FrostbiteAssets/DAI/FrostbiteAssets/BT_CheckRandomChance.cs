namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_CheckRandomChance : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public float Value { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BTEvalFunc : BTFunc
	{
		[FieldOffset(12, 32)]
		public bool Inverted { get; set; }
	}
}

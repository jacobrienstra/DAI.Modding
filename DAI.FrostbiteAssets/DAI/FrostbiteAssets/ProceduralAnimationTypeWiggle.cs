using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProceduralAnimationTypeWiggle : ProceduralAnimationTypeSimple
	{
		[FieldOffset(20, 40)]
		public ProceduralAnimationWiggleMethod WiggleMethod { get; set; }
	}
}

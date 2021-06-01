using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProceduralAnimationTypeWind : ProceduralAnimationTypeSimple
	{
		[FieldOffset(20, 40)]
		public ProceduralAnimationWindMethod WindMethod { get; set; }
	}
}

using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ClothObjectBlueprint : ObjectBlueprint
	{
		[FieldOffset(36, 192)]
		public TimeDeltaType TimeDeltaType { get; set; }
	}
}

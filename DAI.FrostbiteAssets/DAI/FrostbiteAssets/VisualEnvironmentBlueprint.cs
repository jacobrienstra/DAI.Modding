using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class VisualEnvironmentBlueprint : ObjectBlueprint
	{
		[FieldOffset(36, 192)]
		public TimeDeltaType TimeDeltaType { get; set; }
	}
}

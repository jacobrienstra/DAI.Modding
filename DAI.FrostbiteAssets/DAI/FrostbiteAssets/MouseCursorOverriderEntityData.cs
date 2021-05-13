using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MouseCursorOverriderEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public MouseCursor CursorToOverride { get; set; }
	}
}

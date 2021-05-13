using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class AreaTriggerBaseData : TriggerEntityData
	{
		[FieldOffset(96, 192)]
		public LinearTransform GeometryTransform { get; set; }

		[FieldOffset(160, 256)]
		public UpdatePass UpdatePass { get; set; }
	}
}

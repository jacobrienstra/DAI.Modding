using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ANTBlendKeyframe : TimelineKeyframeData
	{
		[FieldOffset(8, 24)]
		public float Time { get; set; }

		[FieldOffset(12, 28)]
		public float Length { get; set; }

		[FieldOffset(16, 32)]
		public ANTBlendCurveType BlendCurveType { get; set; }

		[FieldOffset(20, 36)]
		public float BlendScale { get; set; }

		[FieldOffset(24, 40)]
		public ExternalObject<CurveData> CurveData { get; set; }
	}
}

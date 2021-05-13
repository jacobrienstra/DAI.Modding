namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatTrackData : PropertyTrackBaseData
	{
		[FieldOffset(32, 144)]
		public ExternalObject<CurveData> CurveData { get; set; }
	}
}

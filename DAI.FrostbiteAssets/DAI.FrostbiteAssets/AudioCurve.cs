using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioCurve : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<AudioCurvePoint> Points { get; set; }

		[FieldOffset(4, 8)]
		public AudioCurveType CurveType { get; set; }

		public AudioCurve()
		{
			Points = new List<AudioCurvePoint>();
		}
	}
}

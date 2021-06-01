using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TextFloatySetting : LinkObject
	{
		[FieldOffset(0, 0)]
		public ClientTextFloatyType FloatyType { get; set; }

		[FieldOffset(4, 4)]
		public float DurationSec { get; set; }

		[FieldOffset(8, 8)]
		public float FadeInSec { get; set; }

		[FieldOffset(12, 12)]
		public float FadeOutSec { get; set; }

		[FieldOffset(16, 16)]
		public float Distance { get; set; }

		[FieldOffset(20, 20)]
		public float DirectionAngleDegrees { get; set; }

		[FieldOffset(24, 24)]
		public float EaseOutFactor { get; set; }

		[FieldOffset(28, 28)]
		public float SequenceAngleDegrees { get; set; }

		[FieldOffset(32, 32)]
		public List<int> AngleSequenceMultipliers { get; set; }

		public TextFloatySetting()
		{
			AngleSequenceMultipliers = new List<int>();
		}
	}
}

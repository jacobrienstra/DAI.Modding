using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class TransformPartPropertyTrackData : PropertyTrackData
	{
		[FieldOffset(16, 48)]
		public long Resource { get; set; }

		[FieldOffset(24, 56)]
		public TransformPart TransformPart { get; set; }

		[FieldOffset(28, 60)]
		public CurveInfinityType PreInfinity { get; set; }

		[FieldOffset(32, 64)]
		public CurveInfinityType PostInfinity { get; set; }

		[FieldOffset(36, 72)]
		public List<TransformPartPropertyKey> Values { get; set; }

		[FieldOffset(40, 80)]
		public float EvaluatorFps { get; set; }

		[FieldOffset(44, 84)]
		public uint KeyStartIndex { get; set; }

		[FieldOffset(48, 88)]
		public uint KeyCount { get; set; }

		[FieldOffset(52, 92)]
		public bool Weighted { get; set; }

		[FieldOffset(53, 93)]
		public bool IsStatic { get; set; }

		public TransformPartPropertyTrackData()
		{
			Values = new List<TransformPartPropertyKey>();
		}
	}
}

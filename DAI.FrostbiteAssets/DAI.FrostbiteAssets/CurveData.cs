using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CurveData : DataContainer
	{
		[FieldOffset(8, 24)]
		public InfinityType PreInfinity { get; set; }

		[FieldOffset(12, 28)]
		public InfinityType PostInfinity { get; set; }

		[FieldOffset(16, 32)]
		public CurveType CurveType { get; set; }

		[FieldOffset(20, 40)]
		public List<float> X { get; set; }

		[FieldOffset(24, 48)]
		public List<float> Y { get; set; }

		[FieldOffset(28, 56)]
		public List<float> InTanX { get; set; }

		[FieldOffset(32, 64)]
		public List<float> InTanY { get; set; }

		[FieldOffset(36, 72)]
		public List<float> OutTanX { get; set; }

		[FieldOffset(40, 80)]
		public List<float> OutTanY { get; set; }

		[FieldOffset(44, 88)]
		public bool IsWeighted { get; set; }

		[FieldOffset(45, 89)]
		public bool IsStatic { get; set; }

		public CurveData()
		{
			X = new List<float>();
			Y = new List<float>();
			InTanX = new List<float>();
			InTanY = new List<float>();
			OutTanX = new List<float>();
			OutTanY = new List<float>();
		}
	}
}

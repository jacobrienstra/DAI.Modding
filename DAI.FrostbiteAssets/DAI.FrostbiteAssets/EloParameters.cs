using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EloParameters : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<EloFunctionPoint> KWinner { get; set; }

		[FieldOffset(4, 8)]
		public List<EloFunctionPoint> KLoser { get; set; }

		[FieldOffset(8, 16)]
		public List<EloFunctionPoint> KNewbie { get; set; }

		[FieldOffset(12, 24)]
		public List<EloFunctionPoint> KCompetitor { get; set; }

		[FieldOffset(16, 32)]
		public List<EloExpectedFunctionPoint> Expected { get; set; }

		public EloParameters()
		{
			KWinner = new List<EloFunctionPoint>();
			KLoser = new List<EloFunctionPoint>();
			KNewbie = new List<EloFunctionPoint>();
			KCompetitor = new List<EloFunctionPoint>();
			Expected = new List<EloExpectedFunctionPoint>();
		}
	}
}

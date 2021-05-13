using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotCurveData : DataContainer
	{
		[FieldOffset(8, 24)]
		public CinebotReactionInput ReactionInput { get; set; }

		[FieldOffset(12, 32)]
		public string BlackBoardVarName { get; set; }

		[FieldOffset(16, 40)]
		public float OutputScale { get; set; }

		[FieldOffset(20, 44)]
		public float InputScale { get; set; }

		[FieldOffset(24, 48)]
		public List<ExternalObject<Dummy>> Conditions { get; set; }

		[FieldOffset(28, 56)]
		public List<Vec3> ReactionCurve { get; set; }

		[FieldOffset(32, 64)]
		public bool MirrorInput { get; set; }

		[FieldOffset(33, 65)]
		public bool XOR_Conditions { get; set; }

		public CinebotCurveData()
		{
			Conditions = new List<ExternalObject<Dummy>>();
			ReactionCurve = new List<Vec3>();
		}
	}
}

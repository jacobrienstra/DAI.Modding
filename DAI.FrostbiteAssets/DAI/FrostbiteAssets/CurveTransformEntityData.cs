using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CurveTransformEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public List<Vec3> ReactionCurve { get; set; }

		[FieldOffset(24, 112)]
		public float In { get; set; }

		public CurveTransformEntityData()
		{
			ReactionCurve = new List<Vec3>();
		}
	}
}

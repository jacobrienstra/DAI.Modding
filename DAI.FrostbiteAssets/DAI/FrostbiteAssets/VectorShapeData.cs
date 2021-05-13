using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class VectorShapeData : BaseShapeData
	{
		[FieldOffset(16, 96)]
		public List<Vec3> Points { get; set; }

		[FieldOffset(20, 104)]
		public float Tension { get; set; }

		[FieldOffset(24, 108)]
		public bool IsClosed { get; set; }

		[FieldOffset(25, 109)]
		public bool AllowRoll { get; set; }

		public VectorShapeData()
		{
			Points = new List<Vec3>();
		}
	}
}

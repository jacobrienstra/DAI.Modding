using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PathLinkEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public List<Vec3> Points { get; set; }

		[FieldOffset(84, 184)]
		public PathLinkDirection Direction { get; set; }

		[FieldOffset(88, 192)]
		public ExternalObject<DA3LinkDat> LinkDat { get; set; }

		[FieldOffset(92, 200)]
		public bool ActiveAtStart { get; set; }

		[FieldOffset(93, 201)]
		public bool DeferredCreation { get; set; }

		public PathLinkEntityData()
		{
			Points = new List<Vec3>();
		}
	}
}

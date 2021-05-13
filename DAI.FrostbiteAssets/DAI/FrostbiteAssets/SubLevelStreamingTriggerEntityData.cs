using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SubLevelStreamingTriggerEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public Vec3 TriggerColor { get; set; }

		[FieldOffset(96, 192)]
		public string TriggerName { get; set; }

		[FieldOffset(100, 200)]
		public int Category { get; set; }

		[FieldOffset(104, 204)]
		public SubLevelStreamingNonSpatialRequestType NonSpatialRequestType { get; set; }

		[FieldOffset(108, 208)]
		public float SoftRequestRadius { get; set; }

		[FieldOffset(112, 212)]
		public float HardRequestRadius { get; set; }

		[FieldOffset(116, 216)]
		public List<SubLevelStreamingVectorShapeCap> SoftRequestVectorShapeCaps { get; set; }

		[FieldOffset(120, 224)]
		public List<SubLevelStreamingVectorShapeCap> HardRequestVectorShapeCaps { get; set; }

		[FieldOffset(124, 232)]
		public List<SubLevelStreamingShapeApproximation> SoftRequestGeometryApproximations { get; set; }

		[FieldOffset(128, 240)]
		public List<SubLevelStreamingShapeApproximation> HardRequestGeometryApproximations { get; set; }

		[FieldOffset(132, 248)]
		public bool CacheSoftRequestGeometryLinkArray { get; set; }

		[FieldOffset(133, 249)]
		public bool CacheHardRequestGeometryLinkArray { get; set; }

		public SubLevelStreamingTriggerEntityData()
		{
			SoftRequestVectorShapeCaps = new List<SubLevelStreamingVectorShapeCap>();
			HardRequestVectorShapeCaps = new List<SubLevelStreamingVectorShapeCap>();
			SoftRequestGeometryApproximations = new List<SubLevelStreamingShapeApproximation>();
			HardRequestGeometryApproximations = new List<SubLevelStreamingShapeApproximation>();
		}
	}
}

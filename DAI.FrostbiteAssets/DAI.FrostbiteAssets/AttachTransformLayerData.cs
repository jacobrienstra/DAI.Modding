using System;
using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class AttachTransformLayerData : TransformLayerData
	{
		[FieldOffset(32, 144)]
		public LinearTransform AttachOffset { get; set; }

		[FieldOffset(96, 208)]
		public ExternalObject<TimelineTrackData> AttachEntity { get; set; }

		[FieldOffset(100, 216)]
		public string ChildBoneName { get; set; }

		[FieldOffset(104, 224)]
		public string ParentBoneName { get; set; }

		[FieldOffset(108, 232)]
		public List<Guid> AttachEntityGuidChain { get; set; }

		public AttachTransformLayerData()
		{
			AttachEntityGuidChain = new List<Guid>();
		}
	}
}

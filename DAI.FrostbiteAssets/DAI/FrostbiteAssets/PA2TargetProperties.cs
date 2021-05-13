using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PA2TargetProperties : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<PA2BoneList>> BoneTargets { get; set; }

		public PA2TargetProperties()
		{
			BoneTargets = new List<ExternalObject<PA2BoneList>>();
		}
	}
}

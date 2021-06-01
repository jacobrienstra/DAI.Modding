using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMAnimationType : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<AntRef> StartBools { get; set; }

		[FieldOffset(16, 80)]
		public List<AntRef> EndBools { get; set; }

		[FieldOffset(20, 88)]
		public AntRef ControllerPointer { get; set; }

		[FieldOffset(40, 136)]
		public AntRef Enumeration_TEMP { get; set; }

		public CSMAnimationType()
		{
			StartBools = new List<AntRef>();
			EndBools = new List<AntRef>();
		}
	}
}

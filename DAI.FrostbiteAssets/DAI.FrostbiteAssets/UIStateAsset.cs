using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIStateAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<UIDirectAccessCompData>> UIComponents { get; set; }

		[FieldOffset(16, 80)]
		public List<Dummy> ActionscriptNames { get; set; }

		[FieldOffset(20, 88)]
		public string StateName { get; set; }

		[FieldOffset(24, 96)]
		public string StatePath { get; set; }

		public UIStateAsset()
		{
			UIComponents = new List<ExternalObject<UIDirectAccessCompData>>();
			ActionscriptNames = new List<Dummy>();
		}
	}
}

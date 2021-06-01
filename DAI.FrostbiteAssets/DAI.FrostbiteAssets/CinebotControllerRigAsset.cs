using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotControllerRigAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<CinebotControllerData>> Controllers { get; set; }

		[FieldOffset(16, 80)]
		public bool ForceAllInputTypesEnabled { get; set; }

		public CinebotControllerRigAsset()
		{
			Controllers = new List<ExternalObject<CinebotControllerData>>();
		}
	}
}

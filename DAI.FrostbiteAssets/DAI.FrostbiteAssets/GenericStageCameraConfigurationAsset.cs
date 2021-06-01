using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GenericStageCameraConfigurationAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<StageCameraCinebotMode> DefaultStageCameraMode { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<StageCameraCinebotMode>> StageCameraCinebotModes { get; set; }

		public GenericStageCameraConfigurationAsset()
		{
			StageCameraCinebotModes = new List<ExternalObject<StageCameraCinebotMode>>();
		}
	}
}

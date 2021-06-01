using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SimpleConversationControllerData : ThirdPersonGameCameraControllerData
	{
		[FieldOffset(320, 432)]
		public List<float> DefaultYawAlternatives { get; set; }

		public SimpleConversationControllerData()
		{
			DefaultYawAlternatives = new List<float>();
		}
	}
}

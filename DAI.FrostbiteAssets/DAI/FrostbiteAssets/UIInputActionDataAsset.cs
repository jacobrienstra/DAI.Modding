using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIInputActionDataAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public float DefaultRepeatDelaySec { get; set; }

		[FieldOffset(16, 76)]
		public float DefaultRepeatSpeedSec { get; set; }

		[FieldOffset(20, 80)]
		public float DefaultOneAxisDeadZone { get; set; }

		[FieldOffset(24, 84)]
		public float DefaultTwoAxisDeadZone { get; set; }

		[FieldOffset(28, 88)]
		public List<UIInputActionMapData> InputActionMaps { get; set; }

		[FieldOffset(32, 96)]
		public List<UIAnalogInputMapData> AnalogInputMaps { get; set; }

		public UIInputActionDataAsset()
		{
			InputActionMaps = new List<UIInputActionMapData>();
			AnalogInputMaps = new List<UIAnalogInputMapData>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioComponentSpawnData : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<AudioMovementData> MovementData { get; set; }

		[FieldOffset(12, 32)]
		public List<Dummy> InputParameters { get; set; }

		[FieldOffset(16, 40)]
		public ExternalObject<SlotSoundActionList> SlotSoundActionList { get; set; }

		public AudioComponentSpawnData()
		{
			InputParameters = new List<Dummy>();
		}
	}
}

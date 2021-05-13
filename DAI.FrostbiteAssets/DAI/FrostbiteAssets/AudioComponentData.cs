using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class AudioComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public float IsPlayer { get; set; }

		[FieldOffset(100, 184)]
		public ExternalObject<SlotSoundActionList> SlotSoundActionList { get; set; }

		[FieldOffset(104, 192)]
		public int FilterId { get; set; }

		[FieldOffset(108, 200)]
		public List<string> InputParameters { get; set; }

		[FieldOffset(112, 208)]
		public ExternalObject<Dummy> CombatData { get; set; }

		[FieldOffset(116, 216)]
		public ExternalObject<AudioMovementData> MovementData { get; set; }

		public AudioComponentData()
		{
			InputParameters = new List<string>();
		}
	}
}

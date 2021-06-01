using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundBehaviorEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<WindSoundEmitterBehaviorData> BehaviorData { get; set; }

		[FieldOffset(20, 104)]
		public List<string> SubLevelNames { get; set; }

		[FieldOffset(24, 112)]
		public List<SublevelEmitterList> Emitters { get; set; }

		public SoundBehaviorEntityData()
		{
			SubLevelNames = new List<string>();
			Emitters = new List<SublevelEmitterList>();
		}
	}
}

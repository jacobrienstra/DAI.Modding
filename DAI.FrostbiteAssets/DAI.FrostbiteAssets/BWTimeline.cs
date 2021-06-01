using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTimeline : BWTimelineBase
	{
		[FieldOffset(20, 104)]
		public ExternalObject<FloatProvider> Duration { get; set; }

		[FieldOffset(24, 112)]
		public List<BWTimelineTagRef> Tags { get; set; }

		[FieldOffset(28, 120)]
		public bool Looping { get; set; }

		[FieldOffset(29, 121)]
		public bool AutoExpire { get; set; }

		[FieldOffset(30, 122)]
		public bool RemoveOnCharacterDeath { get; set; }

		[FieldOffset(31, 123)]
		public bool RemoveOnCombatEnd { get; set; }

		[FieldOffset(32, 124)]
		public bool UseAnimationClock { get; set; }

		[FieldOffset(33, 125)]
		public bool ReferenceCounted { get; set; }

		public BWTimeline()
		{
			Tags = new List<BWTimelineTagRef>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCollisionAreaOfEffect : BWCollision
	{
		[FieldOffset(80, 128)]
		public List<ExternalObject<BWCSMAction>> AoeCollisionShapes { get; set; }

		[FieldOffset(84, 136)]
		public BWTimelineTagRef IncludeTaggedActors { get; set; }

		[FieldOffset(88, 152)]
		public BWTimelineTagRef ExcludeTaggedActors { get; set; }

		[FieldOffset(92, 168)]
		public int MinHits { get; set; }

		[FieldOffset(96, 172)]
		public float DistributeImpactsOverTime { get; set; }

		[FieldOffset(100, 176)]
		public ExternalObject<TransformProvider> LineCheckSource { get; set; }

		[FieldOffset(104, 184)]
		public bool HitClosestFirst { get; set; }

		[FieldOffset(105, 185)]
		public bool ShouldLineCheckTargets { get; set; }

		public BWCollisionAreaOfEffect()
		{
			AoeCollisionShapes = new List<ExternalObject<BWCSMAction>>();
		}
	}
}

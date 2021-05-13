using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCollisionMelee : BWCollision
	{
		[FieldOffset(80, 128)]
		public ExternalObject<DA3ImpactDescriptor> Impact { get; set; }

		[FieldOffset(84, 136)]
		public string CollisionId { get; set; }

		[FieldOffset(88, 144)]
		public List<BakedCollisionKeyframe> BakedTransforms { get; set; }

		public BWCollisionMelee()
		{
			BakedTransforms = new List<BakedCollisionKeyframe>();
		}
	}
}

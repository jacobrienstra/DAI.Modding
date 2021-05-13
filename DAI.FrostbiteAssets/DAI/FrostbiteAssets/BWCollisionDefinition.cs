using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCollisionDefinition : DataContainer
	{
		[FieldOffset(8, 24)]
		public string CollisionId { get; set; }

		[FieldOffset(12, 32)]
		public int BoneId { get; set; }

		[FieldOffset(16, 40)]
		public List<CollisionSphere> Spheres { get; set; }

		[FieldOffset(20, 48)]
		public MaterialDecl MaterialPair { get; set; }

		public BWCollisionDefinition()
		{
			Spheres = new List<CollisionSphere>();
		}
	}
}

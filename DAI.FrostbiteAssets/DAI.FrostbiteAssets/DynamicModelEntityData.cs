namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DynamicModelEntityData : DynamicGamePhysicsEntityData
	{
		[FieldOffset(128, 240)]
		public ExternalObject<RigidMeshAsset> Mesh { get; set; }

		[FieldOffset(132, 248)]
		public uint DestructiblePartCount { get; set; }

		[FieldOffset(136, 252)]
		public bool NoCollision { get; set; }
	}
}

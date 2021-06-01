namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BangerEntityData : DynamicGamePhysicsEntityData
	{
		[FieldOffset(128, 240)]
		public ExternalObject<RigidMeshAsset> Mesh { get; set; }

		[FieldOffset(132, 248)]
		public ExternalObject<Dummy> Explosion { get; set; }

		[FieldOffset(136, 256)]
		public float TimeToLive { get; set; }

		[FieldOffset(140, 260)]
		public uint DestructiblePartCount { get; set; }

		[FieldOffset(144, 264)]
		public bool UseVariableNetworkFrequency { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ObstacleDat : DataContainer
	{
		[FieldOffset(8, 24)]
		public uint LayerMask { get; set; }

		[FieldOffset(12, 28)]
		public float PenaltyMult { get; set; }

		[FieldOffset(16, 32)]
		public uint ObstacleBlockageFlags { get; set; }

		[FieldOffset(20, 40)]
		public ExternalObject<Dummy> UserData { get; set; }

		[FieldOffset(24, 48)]
		public string ObstacleName { get; set; }
	}
}

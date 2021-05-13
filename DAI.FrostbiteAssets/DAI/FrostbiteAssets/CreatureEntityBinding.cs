namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureEntityBinding : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntRef FlightPitch { get; set; }

		[FieldOffset(20, 48)]
		public AntRef ForceEnableLockToNavGraph { get; set; }

		[FieldOffset(40, 96)]
		public AntRef ForceDisableLockToNavGraph { get; set; }

		[FieldOffset(60, 144)]
		public AntRef AIControlled { get; set; }

		[FieldOffset(80, 192)]
		public AntRef RigScale { get; set; }

		[FieldOffset(100, 240)]
		public AntRef HighLod { get; set; }

		[FieldOffset(120, 288)]
		public AntRef MediumLod { get; set; }
	}
}

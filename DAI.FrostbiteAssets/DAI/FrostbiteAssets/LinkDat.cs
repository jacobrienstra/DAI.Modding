using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LinkDat : DataContainer
	{
		[FieldOffset(8, 24)]
		public uint LayerMask { get; set; }

		[FieldOffset(12, 28)]
		public NavLinkType LinkType { get; set; }

		[FieldOffset(16, 32)]
		public uint LinkUsageFlags { get; set; }

		[FieldOffset(20, 36)]
		public float PenaltyMult { get; set; }

		[FieldOffset(24, 40)]
		public float MaxSnapDist { get; set; }

		[FieldOffset(28, 44)]
		public float MayUseDist { get; set; }

		[FieldOffset(32, 48)]
		public float MustUseDist { get; set; }

		[FieldOffset(36, 56)]
		public ExternalObject<DA3PathLink> UserData { get; set; }

		[FieldOffset(40, 64)]
		public ExternalObject<Dummy> LinkFlowTune { get; set; }

		[FieldOffset(44, 72)]
		public bool StopToUseLink { get; set; }
	}
}

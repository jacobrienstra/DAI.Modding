using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LookAtLayerInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public int BaseBone { get; set; }

		[FieldOffset(4, 4)]
		public AxisType ForwardAxis { get; set; }

		[FieldOffset(8, 8)]
		public AxisType LeftAxis { get; set; }

		[FieldOffset(12, 12)]
		public AxisType UpAxis { get; set; }

		[FieldOffset(16, 16)]
		public AntRef YawGamestate { get; set; }

		[FieldOffset(36, 64)]
		public AntRef PitchGamestate { get; set; }
	}
}

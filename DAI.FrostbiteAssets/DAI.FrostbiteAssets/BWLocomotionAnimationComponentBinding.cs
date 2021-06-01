namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWLocomotionAnimationComponentBinding : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntRef Accelleration { get; set; }

		[FieldOffset(20, 48)]
		public AntRef Stopping { get; set; }

		[FieldOffset(40, 96)]
		public AntRef RotationalAccelleration { get; set; }

		[FieldOffset(60, 144)]
		public AntRef RotationalSpeed { get; set; }
	}
}

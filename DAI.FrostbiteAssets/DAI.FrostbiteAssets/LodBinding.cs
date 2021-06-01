namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LodBinding : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntRef DisableControllerUpdate { get; set; }

		[FieldOffset(20, 48)]
		public AntRef DisablePoseUpdate { get; set; }

		[FieldOffset(40, 96)]
		public AntRef DistanceFromCamera { get; set; }

		[FieldOffset(60, 144)]
		public AntRef AnimatableInstanceId { get; set; }

		[FieldOffset(80, 192)]
		public AntRef ResetController { get; set; }
	}
}

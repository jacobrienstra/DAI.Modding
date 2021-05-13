namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMArmourStateChangedCallback : ArmourStateChangedCallback
	{
		[FieldOffset(8, 24)]
		public BWTimelineReference BarrierUp { get; set; }

		[FieldOffset(12, 32)]
		public BWTimelineReference BarrierDown { get; set; }

		[FieldOffset(16, 40)]
		public BWTimelineReference ArmourUp { get; set; }

		[FieldOffset(20, 48)]
		public BWTimelineReference ArmourDown { get; set; }

		[FieldOffset(24, 56)]
		public BWTimelineReference HealthUp { get; set; }

		[FieldOffset(28, 64)]
		public BWTimelineReference HealthDown { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(1)]
	public class PlatformScalableBool
	{
		[FieldOffset(0, 0)]
		public bool Default { get; set; }

		[FieldOffset(1, 1)]
		public bool Xenon { get; set; }

		[FieldOffset(2, 2)]
		public bool Ps3 { get; set; }

		[FieldOffset(3, 3)]
		public bool Gen4a { get; set; }

		[FieldOffset(4, 4)]
		public bool Gen4b { get; set; }

		[FieldOffset(5, 5)]
		public bool Android { get; set; }

		[FieldOffset(6, 6)]
		public bool iOS { get; set; }

		[FieldOffset(7, 7)]
		public bool OSX { get; set; }
	}
}

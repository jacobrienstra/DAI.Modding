namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WindowSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public int PosX { get; set; }

		[FieldOffset(20, 44)]
		public int PosY { get; set; }

		[FieldOffset(24, 48)]
		public uint Width { get; set; }

		[FieldOffset(28, 52)]
		public uint Height { get; set; }

		[FieldOffset(32, 56)]
		public bool AutoSize { get; set; }

		[FieldOffset(33, 57)]
		public bool FullscreenAutoSize { get; set; }

		[FieldOffset(34, 58)]
		public bool EnableEscape { get; set; }

		[FieldOffset(35, 59)]
		public bool EnableInputOnActivate { get; set; }

		[FieldOffset(36, 60)]
		public bool HibernateOnClose { get; set; }

		[FieldOffset(37, 61)]
		public bool Hidden { get; set; }

		[FieldOffset(38, 62)]
		public bool Minimized { get; set; }
	}
}

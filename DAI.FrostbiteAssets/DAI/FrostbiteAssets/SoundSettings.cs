namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public string AudioSystemUri { get; set; }

		[FieldOffset(20, 48)]
		public string VOCommon { get; set; }

		[FieldOffset(24, 56)]
		public string VOEnglish { get; set; }

		[FieldOffset(28, 64)]
		public string VOSpanish { get; set; }

		[FieldOffset(32, 72)]
		public string VOFrench { get; set; }

		[FieldOffset(36, 80)]
		public string VOGerman { get; set; }

		[FieldOffset(40, 88)]
		public string VOItalian { get; set; }

		[FieldOffset(44, 96)]
		public bool Enable { get; set; }
	}
}

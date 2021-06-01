namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PresenceBosFileServiceData : PresenceServiceData
	{
		[FieldOffset(12, 72)]
		public string FileGetUrl { get; set; }

		[FieldOffset(16, 80)]
		public int FileGetRetries { get; set; }

		[FieldOffset(20, 88)]
		public string FilePutUrl { get; set; }

		[FieldOffset(24, 96)]
		public int FilePutRetries { get; set; }
	}
}

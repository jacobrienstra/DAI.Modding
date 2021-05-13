namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpeechEventKeyframe
	{
		[FieldOffset(0, 0)]
		public float Time { get; set; }

		[FieldOffset(4, 4)]
		public float SubtitleDisplayLength { get; set; }

		[FieldOffset(8, 8)]
		public int Order { get; set; }

		[FieldOffset(12, 12)]
		public int SpeechStringId { get; set; }

		[FieldOffset(16, 16)]
		public bool ManagedByConversationEditor { get; set; }

		[FieldOffset(17, 17)]
		public bool SuppressVO { get; set; }

		[FieldOffset(18, 18)]
		public bool PlayPastEndOfMovieHack { get; set; }
	}
}

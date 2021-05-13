namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetAudioComponentParameter : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public string Parameter { get; set; }

		[FieldOffset(32, 80)]
		public float Value { get; set; }

		[FieldOffset(36, 84)]
		public bool Relative { get; set; }
	}
}

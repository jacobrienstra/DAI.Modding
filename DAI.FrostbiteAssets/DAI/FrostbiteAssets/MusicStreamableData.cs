namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicStreamableData : MusicPlayableData
	{
		[FieldOffset(40, 64)]
		public float RangeValue { get; set; }

		[FieldOffset(44, 68)]
		public int Weight { get; set; }

		[FieldOffset(48, 72)]
		public ExternalObject<MusicStreamableData> NextPlayable { get; set; }

		[FieldOffset(52, 80)]
		public ExternalObject<Dummy> OnNextPlayableOverlay { get; set; }

		[FieldOffset(56, 88)]
		public float NextPlayableFadeInTime { get; set; }

		[FieldOffset(60, 92)]
		public bool AllowRangeFade { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWLogGameEventData : EntityData
	{
		[FieldOffset(16, 96)]
		public string EventCategory { get; set; }

		[FieldOffset(20, 104)]
		public string EventName { get; set; }

		[FieldOffset(24, 112)]
		public int IntResult { get; set; }

		[FieldOffset(28, 116)]
		public float FloatResult { get; set; }

		[FieldOffset(32, 120)]
		public string StringResult { get; set; }

		[FieldOffset(36, 128)]
		public bool LogToTelemetry { get; set; }
	}
}

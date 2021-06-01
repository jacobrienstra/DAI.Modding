namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_SetShaderParameterKeyframed : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public float MidPointTime1 { get; set; }

		[FieldOffset(32, 80)]
		public Vec4 OnValue { get; set; }

		[FieldOffset(48, 96)]
		public Vec4 MidValue1 { get; set; }

		[FieldOffset(64, 112)]
		public Vec4 MidValue2 { get; set; }

		[FieldOffset(80, 128)]
		public Vec4 OffValue { get; set; }

		[FieldOffset(96, 144)]
		public float MidPointTime2 { get; set; }

		[FieldOffset(100, 152)]
		public string ParameterName { get; set; }

		[FieldOffset(104, 160)]
		public int Index { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_SetShaderParameter : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public string ParameterName { get; set; }

		[FieldOffset(32, 80)]
		public Vec4 OnValue { get; set; }

		[FieldOffset(48, 96)]
		public Vec4 OffValue { get; set; }

		[FieldOffset(64, 112)]
		public int Index { get; set; }
	}
}

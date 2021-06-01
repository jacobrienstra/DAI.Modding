namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class MeshCopyShaderParam : LinkObject
	{
		[FieldOffset(0, 0)]
		public Vec4 OnValue { get; set; }

		[FieldOffset(16, 16)]
		public Vec4 MidValue1 { get; set; }

		[FieldOffset(32, 32)]
		public Vec4 MidValue2 { get; set; }

		[FieldOffset(48, 48)]
		public Vec4 OffValue { get; set; }

		[FieldOffset(64, 64)]
		public float MidPointTime1 { get; set; }

		[FieldOffset(68, 68)]
		public float MidPointTime2 { get; set; }

		[FieldOffset(72, 72)]
		public string ParameterName { get; set; }
	}
}

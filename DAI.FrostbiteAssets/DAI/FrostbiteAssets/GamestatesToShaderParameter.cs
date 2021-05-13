namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GamestatesToShaderParameter : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntRef GamestateX { get; set; }

		[FieldOffset(20, 48)]
		public AntRef GamestateY { get; set; }

		[FieldOffset(40, 96)]
		public AntRef GamestateZ { get; set; }

		[FieldOffset(60, 144)]
		public AntRef GamestateW { get; set; }

		[FieldOffset(80, 192)]
		public string ShaderParameterName { get; set; }
	}
}

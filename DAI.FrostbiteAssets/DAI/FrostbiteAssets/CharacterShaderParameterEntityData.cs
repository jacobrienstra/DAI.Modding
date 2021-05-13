namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CharacterShaderParameterEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec4 ParamValue { get; set; }

		[FieldOffset(32, 112)]
		public string ParamName { get; set; }
	}
}

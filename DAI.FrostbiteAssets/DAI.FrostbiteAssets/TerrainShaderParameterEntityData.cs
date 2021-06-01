using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TerrainShaderParameterEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<TerrainShaderParameter> ShaderParameters { get; set; }

		public TerrainShaderParameterEntityData()
		{
			ShaderParameters = new List<TerrainShaderParameter>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GamestatesToShaderParametersEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<GamestatesToShaderParameter> Parameters { get; set; }

		public GamestatesToShaderParametersEntityData()
		{
			Parameters = new List<GamestatesToShaderParameter>();
		}
	}
}

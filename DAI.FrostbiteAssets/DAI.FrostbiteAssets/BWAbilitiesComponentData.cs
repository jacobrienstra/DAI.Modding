using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWAbilitiesComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public List<ExternalObject<DataContainer>> AbilityTrees { get; set; }

		[FieldOffset(100, 184)]
		public List<ExternalObject<DataContainer>> DefaultAbilities { get; set; }

		[FieldOffset(104, 192)]
		public ExternalObject<BWAbilityAliasMap> DefaultAbilityMapping { get; set; }

		[FieldOffset(108, 200)]
		public AntRef StanceEnum { get; set; }

		[FieldOffset(128, 248)]
		public AntRef Changed { get; set; }

		[FieldOffset(148, 296)]
		public List<ExternalObject<Dummy>> CSMList { get; set; }

		public BWAbilitiesComponentData()
		{
			AbilityTrees = new List<ExternalObject<DataContainer>>();
			DefaultAbilities = new List<ExternalObject<DataContainer>>();
			CSMList = new List<ExternalObject<Dummy>>();
		}
	}
}

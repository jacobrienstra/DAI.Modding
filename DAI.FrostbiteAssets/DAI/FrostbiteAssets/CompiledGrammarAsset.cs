using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CompiledGrammarAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<CompiledGrammarVariation> Variations { get; set; }

		public CompiledGrammarAsset()
		{
			Variations = new List<CompiledGrammarVariation>();
		}
	}
}

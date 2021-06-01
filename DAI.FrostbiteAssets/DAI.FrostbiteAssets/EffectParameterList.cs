using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EffectParameterList : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<EffectParameter>> Parameters { get; set; }

		public EffectParameterList()
		{
			Parameters = new List<ExternalObject<EffectParameter>>();
		}
	}
}

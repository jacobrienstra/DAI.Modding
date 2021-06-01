using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundScopeStrategyData : DataContainer
	{
		[FieldOffset(8, 24)]
		public string Name { get; set; }

		[FieldOffset(12, 32)]
		public List<ExternalObject<StreamPoolMapping>> Stages { get; set; }

		public SoundScopeStrategyData()
		{
			Stages = new List<ExternalObject<StreamPoolMapping>>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ExertionComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<SoundAsset> Sound { get; set; }

		[FieldOffset(100, 184)]
		public List<ExternalObject<DataContainer>> ExertionToEventMappings { get; set; }

		[FieldOffset(104, 192)]
		public List<ExternalObject<Dummy>> FilterData { get; set; }

		[FieldOffset(108, 200)]
		public float OcclusionValue { get; set; }

		public ExertionComponentData()
		{
			ExertionToEventMappings = new List<ExternalObject<DataContainer>>();
			FilterData = new List<ExternalObject<Dummy>>();
		}
	}
}

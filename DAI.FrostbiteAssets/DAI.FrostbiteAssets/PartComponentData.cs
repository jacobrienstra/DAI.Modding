using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PartComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public List<ExternalObject<DataContainer>> HealthStates { get; set; }

		[FieldOffset(100, 184)]
		public List<ExternalObject<Dummy>> PartLinks { get; set; }

		[FieldOffset(104, 192)]
		public bool IsSupported { get; set; }

		[FieldOffset(105, 193)]
		public bool IsFragile { get; set; }

		[FieldOffset(106, 194)]
		public bool IsNetworkable { get; set; }

		[FieldOffset(107, 195)]
		public bool IsWindow { get; set; }

		[FieldOffset(108, 196)]
		public bool AnimatePhysics { get; set; }

		public PartComponentData()
		{
			HealthStates = new List<ExternalObject<DataContainer>>();
			PartLinks = new List<ExternalObject<Dummy>>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWTargetComponentData : BWCSMTargetComponentData
	{
		[FieldOffset(96, 176)]
		public List<ExternalObject<DataContainer>> Targets { get; set; }

		[FieldOffset(100, 184)]
		public bool MultiImpactsPerCollision { get; set; }

		[FieldOffset(101, 185)]
		public bool UseLargeGroundRings { get; set; }

		public BWTargetComponentData()
		{
			Targets = new List<ExternalObject<DataContainer>>();
		}
	}
}

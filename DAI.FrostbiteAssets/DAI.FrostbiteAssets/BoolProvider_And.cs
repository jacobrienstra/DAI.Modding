using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_And : BoolProvider
	{
		[FieldOffset(8, 32)]
		public List<ExternalObject<DataContainer>> Params { get; set; }

		public BoolProvider_And()
		{
			Params = new List<ExternalObject<DataContainer>>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_Or : BoolProvider
	{
		[FieldOffset(8, 32)]
		public List<ExternalObject<DataContainer>> Params { get; set; }

		public BoolProvider_Or()
		{
			Params = new List<ExternalObject<DataContainer>>();
		}
	}
}

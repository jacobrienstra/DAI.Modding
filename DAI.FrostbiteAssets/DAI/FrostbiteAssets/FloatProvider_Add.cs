using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_Add : FloatProvider
	{
		[FieldOffset(8, 32)]
		public List<ExternalObject<DataContainer>> Values { get; set; }

		public FloatProvider_Add()
		{
			Values = new List<ExternalObject<DataContainer>>();
		}
	}
}

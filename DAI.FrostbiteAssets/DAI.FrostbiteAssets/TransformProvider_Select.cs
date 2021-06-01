using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TransformProvider_Select : TransformProvider
	{
		[FieldOffset(8, 32)]
		public List<ExternalObject<DataContainer>> Transforms { get; set; }

		public TransformProvider_Select()
		{
			Transforms = new List<ExternalObject<DataContainer>>();
		}
	}
}

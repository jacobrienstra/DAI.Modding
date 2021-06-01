using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Delegate_float : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<Script> TargetScript { get; set; }

		[FieldOffset(4, 8)]
		public List<ExternalObject<DataContainer>> arguments { get; set; }

		[FieldOffset(8, 16)]
		public float DefaultValue { get; set; }

		public Delegate_float()
		{
			arguments = new List<ExternalObject<DataContainer>>();
		}
	}
}

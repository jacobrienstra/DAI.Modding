using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Delegate_bool : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<Script> TargetScript { get; set; }

		[FieldOffset(4, 8)]
		public List<ExternalObject<DataContainer>> arguments { get; set; }

		[FieldOffset(8, 16)]
		public bool DefaultValue { get; set; }

		public Delegate_bool()
		{
			arguments = new List<ExternalObject<DataContainer>>();
		}
	}
}

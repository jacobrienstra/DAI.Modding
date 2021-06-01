using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Delegate_int : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<Script> TargetScript { get; set; }

		[FieldOffset(4, 8)]
		public List<ExternalObject<LogicReferenceObjectData>> arguments { get; set; }

		[FieldOffset(8, 16)]
		public int DefaultValue { get; set; }

		public Delegate_int()
		{
			arguments = new List<ExternalObject<LogicReferenceObjectData>>();
		}
	}
}

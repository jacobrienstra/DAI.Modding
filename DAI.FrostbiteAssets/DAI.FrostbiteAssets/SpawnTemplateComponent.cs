using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpawnTemplateComponent : LinkObject
	{
		[FieldOffset(0, 0)]
		public Guid InstanceRef { get; set; }

		[FieldOffset(16, 16)]
		public ExternalObject<DataContainer> Data { get; set; }
	}
}

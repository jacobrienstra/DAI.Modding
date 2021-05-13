using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ServerBackendAttributeMapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public ServerBackendAttribute Attribute { get; set; }

		[FieldOffset(4, 8)]
		public string Setting { get; set; }

		[FieldOffset(8, 16)]
		public string DefaultValue { get; set; }
	}
}

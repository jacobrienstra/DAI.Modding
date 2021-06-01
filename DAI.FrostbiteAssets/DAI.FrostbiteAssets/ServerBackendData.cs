using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ServerBackendData : Asset
	{
		[FieldOffset(12, 72)]
		public List<ServerBackendAttributeMapping> Mappings { get; set; }

		public ServerBackendData()
		{
			Mappings = new List<ServerBackendAttributeMapping>();
		}
	}
}

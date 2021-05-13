using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DataBusData : Asset
	{
		[FieldOffset(12, 72)]
		public List<PropertyConnection> PropertyConnections { get; set; }

		[FieldOffset(16, 80)]
		public List<LinkConnection> LinkConnections { get; set; }

		[FieldOffset(20, 88)]
		public ExternalObject<InterfaceDescriptorData> Interface { get; set; }

		[FieldOffset(24, 96)]
		public short Flags { get; set; }

		public DataBusData()
		{
			PropertyConnections = new List<PropertyConnection>();
			LinkConnections = new List<LinkConnection>();
		}
	}
}

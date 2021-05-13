using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntityBusData : DataBusData
	{
		[FieldOffset(28, 104)]
		public List<EventConnection> EventConnections { get; set; }

		public EntityBusData()
		{
			EventConnections = new List<EventConnection>();
		}
	}
}

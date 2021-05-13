using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SubTitledNotificationEntityData : NotificationEntityBaseData
	{
		[FieldOffset(48, 160)]
		public int OverrideSubTextStringID { get; set; }

		[FieldOffset(52, 168)]
		public LocalizedStringReference SubTextReference { get; set; }

		[FieldOffset(56, 192)]
		public int SubTitleArgument0 { get; set; }

		[FieldOffset(60, 196)]
		public int SubTitleArgument1 { get; set; }

		[FieldOffset(64, 200)]
		public int SubTitleArgument2 { get; set; }

		[FieldOffset(68, 204)]
		public int SubTitleArgument3 { get; set; }

		[FieldOffset(72, 208)]
		public int SubTitleArgumentCount { get; set; }

		[FieldOffset(76, 216)]
		public List<byte> SubTitleStringIdArgumentNumbers { get; set; }

		public SubTitledNotificationEntityData()
		{
			SubTitleStringIdArgumentNumbers = new List<byte>();
		}
	}
}

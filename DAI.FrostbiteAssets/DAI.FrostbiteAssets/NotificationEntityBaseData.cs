using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class NotificationEntityBaseData : EntityData
	{
		[FieldOffset(16, 96)]
		public int OverrideTitleTextStringID { get; set; }

		[FieldOffset(20, 104)]
		public LocalizedStringReference TitleTextReference { get; set; }

		[FieldOffset(24, 128)]
		public int TitleArgument0 { get; set; }

		[FieldOffset(28, 132)]
		public int TitleArgument1 { get; set; }

		[FieldOffset(32, 136)]
		public int TitleArgument2 { get; set; }

		[FieldOffset(36, 140)]
		public int TitleArgument3 { get; set; }

		[FieldOffset(40, 144)]
		public int TitleArgumentCount { get; set; }

		[FieldOffset(44, 152)]
		public List<byte> TitleStringIdArgumentNumbers { get; set; }

		public NotificationEntityBaseData()
		{
			TitleStringIdArgumentNumbers = new List<byte>();
		}
	}
}

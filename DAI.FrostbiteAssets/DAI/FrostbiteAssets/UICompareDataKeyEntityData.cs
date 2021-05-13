using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICompareDataKeyEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public UISimpleDataSource DataSource { get; set; }

		[FieldOffset(24, 112)]
		public List<string> Values { get; set; }

		[FieldOffset(28, 120)]
		public bool FireEventOnInit { get; set; }

		public UICompareDataKeyEntityData()
		{
			Values = new List<string>();
		}
	}
}

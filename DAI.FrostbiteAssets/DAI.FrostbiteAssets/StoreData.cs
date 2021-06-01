using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StoreData : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public LocalizedStringReference StoreName { get; set; }

		[FieldOffset(16, 96)]
		public List<StoreItem> ItemsForSaleList { get; set; }

		[FieldOffset(20, 104)]
		public List<StoreItem> SpecialOfferList { get; set; }

		[FieldOffset(24, 112)]
		public float BuyMultiplier { get; set; }

		[FieldOffset(28, 116)]
		public float SellMultiplier { get; set; }

		[FieldOffset(32, 120)]
		public PlotConditionReference SalePlotCondition { get; set; }

		[FieldOffset(60, 200)]
		public float SaleSellMultiplier { get; set; }

		public StoreData()
		{
			ItemsForSaleList = new List<StoreItem>();
			SpecialOfferList = new List<StoreItem>();
		}
	}
}

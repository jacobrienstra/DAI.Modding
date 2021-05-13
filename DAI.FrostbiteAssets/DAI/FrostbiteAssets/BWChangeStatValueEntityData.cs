using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWChangeStatValueEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public ExternalObject<BWStat> Stat { get; set; }

		[FieldOffset(24, 112)]
		public BWChangeStatValueOperation Operation { get; set; }

		[FieldOffset(28, 116)]
		public float Amount { get; set; }
	}
}

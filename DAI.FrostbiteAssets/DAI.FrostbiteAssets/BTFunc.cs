using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BTFunc : DataContainer
	{
		[FieldOffset(8, 24)]
		public EFuncType FuncType { get; set; }
	}
}

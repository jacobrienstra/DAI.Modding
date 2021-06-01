using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIDynamicDataBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public List<UIDataSourceInfo> Bindings { get; set; }

		[FieldOffset(12, 32)]
		public bool Refresh { get; set; }

		public UIDynamicDataBinding()
		{
			Bindings = new List<UIDataSourceInfo>();
		}
	}
}

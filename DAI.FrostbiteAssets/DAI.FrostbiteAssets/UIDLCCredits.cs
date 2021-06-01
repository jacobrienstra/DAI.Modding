using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIDLCCredits : LinkObject
	{
		[FieldOffset(0, 0)]
		public int DLCPackage { get; set; }

		[FieldOffset(4, 8)]
		public List<UIScrollingCreditSection> DLCCredits { get; set; }

		public UIDLCCredits()
		{
			DLCCredits = new List<UIScrollingCreditSection>();
		}
	}
}

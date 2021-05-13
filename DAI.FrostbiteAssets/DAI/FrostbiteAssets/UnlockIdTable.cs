using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UnlockIdTable : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<Dummy> Identifiers { get; set; }

		public UnlockIdTable()
		{
			Identifiers = new List<Dummy>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class NonEnglishToEnglishHashes : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<NonEnglishToEnglishHash> HashArray { get; set; }

		public NonEnglishToEnglishHashes()
		{
			HashArray = new List<NonEnglishToEnglishHash>();
		}
	}
}

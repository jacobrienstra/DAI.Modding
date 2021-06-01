using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CodexAsset : TreeBase
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<CodexEntry>> ChildNodes { get; set; }

		public CodexAsset()
		{
			ChildNodes = new List<ExternalObject<CodexEntry>>();
		}
	}
}

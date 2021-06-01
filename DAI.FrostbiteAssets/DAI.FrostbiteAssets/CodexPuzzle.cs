using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CodexPuzzle : CodexEntry
	{
		[FieldOffset(48, 184)]
		public List<PlotFlagReference> PlotFlags { get; set; }

		[FieldOffset(52, 192)]
		public string PuzzleName { get; set; }

		public CodexPuzzle()
		{
			PlotFlags = new List<PlotFlagReference>();
		}
	}
}

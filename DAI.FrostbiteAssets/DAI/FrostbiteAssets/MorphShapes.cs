using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MorphShapes : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<MorphShape>> Shapes { get; set; }

		public MorphShapes()
		{
			Shapes = new List<ExternalObject<MorphShape>>();
		}
	}
}

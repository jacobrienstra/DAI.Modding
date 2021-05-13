using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FaceFXAnimset : Asset
	{
		[FieldOffset(12, 72)]
		public List<FaceFxAnim> Animations { get; set; }

		public FaceFXAnimset()
		{
			Animations = new List<FaceFxAnim>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundActionList : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<SoundAction>> SoundList { get; set; }

		public SoundActionList()
		{
			SoundList = new List<ExternalObject<SoundAction>>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PA2BoneList : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<ExternalObject<PA2BoneList>> Bones { get; set; }

		public PA2BoneList()
		{
			Bones = new List<ExternalObject<PA2BoneList>>();
		}
	}
}

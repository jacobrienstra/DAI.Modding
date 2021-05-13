using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProfileOptionDataEnum : ProfileOptionData
	{
		[FieldOffset(20, 88)]
		public List<ProfileOptionDataEnumItem> Items { get; set; }

		public ProfileOptionDataEnum()
		{
			Items = new List<ProfileOptionDataEnumItem>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbilityUpgrade : BWAbility
	{
		[FieldOffset(92, 288)]
		public List<BWDepletableStatValuePair> Cost { get; set; }

		public BWAbilityUpgrade()
		{
			Cost = new List<BWDepletableStatValuePair>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureProfile : CreatureProfileBase
	{
		[FieldOffset(12, 72)]
		public BalanceCustomizations BalanceOverride { get; set; }

		[FieldOffset(32, 104)]
		public List<CreatureAppearanceCustomizations> AppearanceOverride { get; set; }

		public CreatureProfile()
		{
			AppearanceOverride = new List<CreatureAppearanceCustomizations>();
		}
	}
}

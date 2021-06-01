using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ExertionCooldownFilterData : SoundsetFilterData
	{
		[FieldOffset(12, 32)]
		public float Cooldown { get; set; }

		[FieldOffset(16, 40)]
		public List<ExternalObject<Dummy>> Overrides { get; set; }

		public ExertionCooldownFilterData()
		{
			Overrides = new List<ExternalObject<Dummy>>();
		}
	}
}

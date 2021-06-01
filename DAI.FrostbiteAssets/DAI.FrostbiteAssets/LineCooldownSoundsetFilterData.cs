using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LineCooldownSoundsetFilterData : SoundsetFilterData
	{
		[FieldOffset(12, 32)]
		public float Cooldown { get; set; }

		[FieldOffset(16, 40)]
		public List<ExternalObject<DataContainer>> LineOverrides { get; set; }

		public LineCooldownSoundsetFilterData()
		{
			LineOverrides = new List<ExternalObject<DataContainer>>();
		}
	}
}

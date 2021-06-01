using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WeaponStyleEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<DataContainer>> WeaponStyles { get; set; }

		public WeaponStyleEntityData()
		{
			WeaponStyles = new List<ExternalObject<DataContainer>>();
		}
	}
}

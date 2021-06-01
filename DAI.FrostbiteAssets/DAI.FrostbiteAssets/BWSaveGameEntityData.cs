using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWSaveGameEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public SaveGameType SaveType { get; set; }
	}
}

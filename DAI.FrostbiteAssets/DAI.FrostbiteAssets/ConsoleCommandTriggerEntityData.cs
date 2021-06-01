using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConsoleCommandTriggerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public string CommandName { get; set; }

		[FieldOffset(20, 104)]
		public Realm Realm { get; set; }
	}
}

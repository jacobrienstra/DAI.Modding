using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlayerFilterEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public bool InvertFilter { get; set; }

		[FieldOffset(21, 101)]
		public bool ForwardToSpectators { get; set; }
	}
}

using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PauseAndPlayManagerProxyEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public float TransitionTime { get; set; }

		[FieldOffset(24, 104)]
		public bool OnlyOneDisablePerEntity { get; set; }
	}
}

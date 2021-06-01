using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FbProxyControllerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public FbProxyControllerEntityBinding CannedAnimBinding { get; set; }

		[FieldOffset(100, 296)]
		public int AnimationEntitySpacePriority { get; set; }

		[FieldOffset(104, 304)]
		public AntRef PointerGameState { get; set; }

		[FieldOffset(124, 352)]
		public bool AlwaysClearEntitySpaceWhenInScenario { get; set; }
	}
}

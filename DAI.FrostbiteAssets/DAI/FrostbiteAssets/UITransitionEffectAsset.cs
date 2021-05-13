namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITransitionEffectAsset : Asset
	{
		[FieldOffset(12, 72)]
		public UITransitionEffectData LoadingEffectData { get; set; }

		[FieldOffset(44, 112)]
		public UITransitionEffectData SavingEffectData { get; set; }

		[FieldOffset(76, 152)]
		public float BlackScreenCutoffPercent { get; set; }

		[FieldOffset(80, 156)]
		public int StageWidth { get; set; }

		[FieldOffset(84, 160)]
		public int StageHeight { get; set; }
	}
}

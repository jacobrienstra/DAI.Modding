namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SpawnTiledVisualEffect : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<TiledVisualEffectEntityData> Effect { get; set; }

		[FieldOffset(32, 80)]
		public bool DestroyOnEnd { get; set; }
	}
}

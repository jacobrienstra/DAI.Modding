namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWSpawnAnimationSpawnData : ExtraSpawnData
	{
		[FieldOffset(8, 24)]
		public ExternalObject<CSMStateReference> OverrideInitialStateRef { get; set; }
	}
}

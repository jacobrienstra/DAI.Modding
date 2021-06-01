namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LightAnimationSpawnData : ExtraSpawnData
	{
		[FieldOffset(8, 24)]
		public AntRef Controller { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AnimationControlledStateData : CharacterStateData
	{
		[FieldOffset(12, 32)]
		public float UpNormalTolerance { get; set; }
	}
}

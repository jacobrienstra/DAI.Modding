namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class JumpStateData : CharacterStateData
	{
		[FieldOffset(12, 32)]
		public float JumpHeight { get; set; }

		[FieldOffset(16, 36)]
		public float JumpEffectSize { get; set; }
	}
}

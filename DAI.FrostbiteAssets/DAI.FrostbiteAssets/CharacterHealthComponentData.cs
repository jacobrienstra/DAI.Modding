namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CharacterHealthComponentData : ControllableHealthComponentData
	{
		[FieldOffset(96, 192)]
		public float MaxHealth { get; set; }

		[FieldOffset(100, 196)]
		public float TimeForCorpse { get; set; }

		[FieldOffset(104, 200)]
		public bool IsImmortal { get; set; }
	}
}

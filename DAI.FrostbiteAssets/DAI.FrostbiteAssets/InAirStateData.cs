namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InAirStateData : CharacterStateData
	{
		[FieldOffset(12, 32)]
		public float FreeFallVelocity { get; set; }
	}
}

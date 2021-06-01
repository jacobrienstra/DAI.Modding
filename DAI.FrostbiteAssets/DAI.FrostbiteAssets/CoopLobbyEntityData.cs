namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CoopLobbyEntityData : GameComponentEntityData
	{
		[FieldOffset(112, 208)]
		public float ClientConnectionTimeout { get; set; }

		[FieldOffset(116, 212)]
		public bool IsInGame { get; set; }
	}
}

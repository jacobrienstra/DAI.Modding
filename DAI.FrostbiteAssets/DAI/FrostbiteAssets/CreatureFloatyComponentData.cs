namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CreatureFloatyComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public int MultiplayerFloatyBoneAttachId { get; set; }

		[FieldOffset(100, 180)]
		public bool MultiplayerSmallFloaty { get; set; }
	}
}

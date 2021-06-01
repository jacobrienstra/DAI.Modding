namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class GameComponentEntityData : ComponentEntityData
	{
		[FieldOffset(96, 192)]
		public bool Enabled { get; set; }
	}
}

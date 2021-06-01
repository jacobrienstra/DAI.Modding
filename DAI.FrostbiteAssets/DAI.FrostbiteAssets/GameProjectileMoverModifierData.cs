namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameProjectileMoverModifierData : DataContainer
	{
		[FieldOffset(8, 24)]
		public bool AffectOrientation { get; set; }
	}
}

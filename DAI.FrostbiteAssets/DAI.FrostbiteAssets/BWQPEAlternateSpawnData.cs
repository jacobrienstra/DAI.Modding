namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWQPEAlternateSpawnData : AlternateSpawnEntityData
	{
		[FieldOffset(96, 192)]
		public bool CanHaveLargePropSet { get; set; }

		[FieldOffset(97, 193)]
		public bool CanHaveSmallPropSet { get; set; }
	}
}

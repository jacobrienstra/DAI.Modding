namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FaceFXPlayerSpawnData : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<FaceFXAsset> FaceFXFile { get; set; }
	}
}

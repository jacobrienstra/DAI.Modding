namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class FaceFXPlayerData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public AntRef FaceFXControllerPointer { get; set; }

		[FieldOffset(116, 224)]
		public ExternalObject<FaceFXAsset> FaceFXFile { get; set; }
	}
}

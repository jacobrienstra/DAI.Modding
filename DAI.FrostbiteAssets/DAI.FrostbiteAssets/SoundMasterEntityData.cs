namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundMasterEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<SoundMasterPatchAsset> Master { get; set; }
	}
}

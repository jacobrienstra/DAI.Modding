namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<MixerAsset> Mixer { get; set; }

		[FieldOffset(20, 104)]
		public bool ActivateOnCreation { get; set; }

		[FieldOffset(21, 105)]
		public bool AccumulatedInputs { get; set; }
	}
}

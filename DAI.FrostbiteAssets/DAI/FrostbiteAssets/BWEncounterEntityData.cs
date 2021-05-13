using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWEncounterEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public string EncounterName { get; set; }

		[FieldOffset(20, 104)]
		public EncounterIntensity Intensity { get; set; }

		[FieldOffset(24, 108)]
		public float PerceptionLossThreshold { get; set; }

		[FieldOffset(28, 112)]
		public UpdatePass UpdatePass { get; set; }

		[FieldOffset(32, 116)]
		public bool SaveState { get; set; }
	}
}

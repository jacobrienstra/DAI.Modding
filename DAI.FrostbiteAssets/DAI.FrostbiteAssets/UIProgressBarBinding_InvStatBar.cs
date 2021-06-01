using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIProgressBarBinding_InvStatBar : UIProgressBarBinding
	{
		[FieldOffset(56, 96)]
		public InvStatBarType StatBarType { get; set; }

		[FieldOffset(60, 100)]
		public float MaxCalcInitialValue { get; set; }

		[FieldOffset(64, 104)]
		public float MaxCalcMultiplier { get; set; }
	}
}

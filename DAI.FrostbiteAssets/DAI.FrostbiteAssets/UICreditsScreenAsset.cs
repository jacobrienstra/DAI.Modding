using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICreditsScreenAsset : UILocalizedScreenAsset
	{
		[FieldOffset(68, 192)]
		public float FadeInTime { get; set; }

		[FieldOffset(72, 196)]
		public float HoldTime { get; set; }

		[FieldOffset(76, 200)]
		public float FadeOutTime { get; set; }

		[FieldOffset(80, 204)]
		public float BreakSpace { get; set; }

		[FieldOffset(84, 208)]
		public float ColumnPadding { get; set; }

		[FieldOffset(88, 212)]
		public float TotalRunningTime { get; set; }

		[FieldOffset(92, 216)]
		public float ScrollingCreditStartTime { get; set; }

		[FieldOffset(96, 224)]
		public List<UITitleCreditEntry> TitleCredits { get; set; }

		[FieldOffset(100, 232)]
		public List<UIScrollingCreditSection> MainCredits { get; set; }

		[FieldOffset(104, 240)]
		public ExternalObject<DLCCreditsConfiguration> DLCCreditsConfig { get; set; }

		[FieldOffset(108, 248)]
		public List<UIScrollingCreditSection> EndCredits { get; set; }

		[FieldOffset(112, 256)]
		public List<UICreditsImage> CreditsImages { get; set; }

		[FieldOffset(116, 264)]
		public List<string> InlineCreditsImages { get; set; }

		[FieldOffset(120, 272)]
		public float ImageFadeInTime { get; set; }

		[FieldOffset(124, 276)]
		public float ImageHoldTime { get; set; }

		[FieldOffset(128, 280)]
		public float ImageFadeOutTime { get; set; }

		public UICreditsScreenAsset()
		{
			TitleCredits = new List<UITitleCreditEntry>();
			MainCredits = new List<UIScrollingCreditSection>();
			EndCredits = new List<UIScrollingCreditSection>();
			CreditsImages = new List<UICreditsImage>();
			InlineCreditsImages = new List<string>();
		}
	}
}

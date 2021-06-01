using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class BWPopUpAsset : Asset
	{
		[FieldOffset(12, 72)]
		public int Priority { get; set; }

		[FieldOffset(16, 76)]
		public BWPopUpQueueType Queue { get; set; }

		[FieldOffset(20, 80)]
		public string FlashLinkageId { get; set; }

		[FieldOffset(24, 88)]
		public LocalizedStringReference Title { get; set; }

		[FieldOffset(28, 112)]
		public LocalizedStringReference Text { get; set; }

		[FieldOffset(32, 136)]
		public UITextureAtlasTextureReference Icon { get; set; }

		[FieldOffset(52, 176)]
		public string IconFrameLabel { get; set; }

		[FieldOffset(56, 184)]
		public double Duration { get; set; }

		[FieldOffset(64, 192)]
		public string StreamInstallGroupName { get; set; }

		[FieldOffset(68, 200)]
		public BWPopUpCloseInputType CloseInputType { get; set; }

		[FieldOffset(72, 208)]
		public List<BWPopUpInput> CustomCloseInputs { get; set; }

		[FieldOffset(76, 216)]
		public Vec2 Offset { get; set; }

		[FieldOffset(84, 224)]
		public AnchorY AnchorVertical { get; set; }

		[FieldOffset(88, 228)]
		public AnchorX AnchorHorizontal { get; set; }

		[FieldOffset(92, 232)]
		public bool IsModal { get; set; }

		[FieldOffset(93, 233)]
		public bool PersistAcrossAreaTransitions { get; set; }

		[FieldOffset(94, 234)]
		public bool OverridePosition { get; set; }

		[FieldOffset(95, 235)]
		public bool IsTutorial { get; set; }

		public BWPopUpAsset()
		{
			CustomCloseInputs = new List<BWPopUpInput>();
		}
	}
}

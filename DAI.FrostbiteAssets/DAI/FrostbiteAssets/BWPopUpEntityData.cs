using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class BWPopUpEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<BWPopUpAsset> PopUpAsset { get; set; }

		[FieldOffset(20, 104)]
		public BWPopUpQueueType Queue { get; set; }

		[FieldOffset(24, 108)]
		public int Priority { get; set; }

		[FieldOffset(28, 112)]
		public string FlashLinkageId { get; set; }

		[FieldOffset(32, 120)]
		public LocalizedStringReference Title { get; set; }

		[FieldOffset(36, 144)]
		public int OverrideTitleStringId { get; set; }

		[FieldOffset(40, 152)]
		public LocalizedStringReference Text { get; set; }

		[FieldOffset(44, 176)]
		public int OverrideTextStringId { get; set; }

		[FieldOffset(48, 184)]
		public UITextureAtlasTextureReference Icon { get; set; }

		[FieldOffset(68, 224)]
		public string IconFrameLabel { get; set; }

		[FieldOffset(72, 232)]
		public double Duration { get; set; }

		[FieldOffset(80, 240)]
		public OverrideBool IsModal { get; set; }

		[FieldOffset(84, 244)]
		public OverrideBool PersistAcrossAreaTransitions { get; set; }

		[FieldOffset(88, 248)]
		public string StreamInstallGroupName { get; set; }

		[FieldOffset(92, 256)]
		public BWPopUpCloseInputType CloseInputType { get; set; }

		[FieldOffset(96, 264)]
		public List<BWPopUpInput> CustomCloseInputs { get; set; }

		[FieldOffset(100, 272)]
		public Vec2 Offset { get; set; }

		[FieldOffset(108, 280)]
		public AnchorY AnchorVertical { get; set; }

		[FieldOffset(112, 284)]
		public AnchorX AnchorHorizontal { get; set; }

		[FieldOffset(116, 288)]
		public OverrideBool IsTutorial { get; set; }

		[FieldOffset(120, 292)]
		public bool OverridePosition { get; set; }

		public BWPopUpEntityData()
		{
			CustomCloseInputs = new List<BWPopUpInput>();
		}
	}
}

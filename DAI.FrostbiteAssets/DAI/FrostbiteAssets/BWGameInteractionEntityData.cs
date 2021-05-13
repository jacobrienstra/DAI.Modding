using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWGameInteractionEntityData : GameInteractionEntityData
	{
		[FieldOffset(128, 224)]
		public List<Vec3> PlayerMovementTargets { get; set; }

		[FieldOffset(132, 232)]
		public BWInteractionType InteractionType { get; set; }

		[FieldOffset(136, 236)]
		public int OverrideInteractionStringID { get; set; }

		[FieldOffset(140, 240)]
		public int OverrideInteractionType { get; set; }

		[FieldOffset(144, 244)]
		public float OverrideUseWithinRadius { get; set; }

		[FieldOffset(148, 248)]
		public float OverrideDisplayWithinRadius { get; set; }

		[FieldOffset(152, 256)]
		public LocalizedStringReference InteractionTextReference { get; set; }

		[FieldOffset(156, 280)]
		public float NormalizedRangeStep { get; set; }

		[FieldOffset(160, 284)]
		public bool DisableGeometryLinkedSelectionHighlight { get; set; }

		[FieldOffset(161, 285)]
		public bool DisableGeometryLinkedSelectionHighlightOnSearch { get; set; }

		[FieldOffset(162, 286)]
		public bool DisabledInDemoMode { get; set; }

		[FieldOffset(163, 287)]
		public bool TargettingEnabled { get; set; }

		[FieldOffset(164, 288)]
		public bool ShowInteractionFloaty { get; set; }

		public BWGameInteractionEntityData()
		{
			PlayerMovementTargets = new List<Vec3>();
		}
	}
}

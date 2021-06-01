using System;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameMusicEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public float dummyProp_DO_NOT_USE { get; set; }

		[FieldOffset(20, 100)]
		public Guid MusicAssetGUID { get; set; }

		[FieldOffset(36, 116)]
		public GameMusic_OnPatchEventBehavior OnPatchEventBehavior { get; set; }

		[FieldOffset(40, 120)]
		public GameMusic_StopBehavior OnStopCurrentBehavior { get; set; }

		[FieldOffset(44, 124)]
		public float FadeOutTime { get; set; }

		[FieldOffset(48, 128)]
		public bool PlayOnCreation { get; set; }
	}
}

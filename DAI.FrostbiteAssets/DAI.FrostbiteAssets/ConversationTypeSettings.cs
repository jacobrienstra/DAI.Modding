using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationTypeSettings : DataContainer
	{
		[FieldOffset(8, 24)]
		public ConversationCameraControlType CameraControl { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<Dummy> CinebotMode { get; set; }

		[FieldOffset(16, 40)]
		public float AutomaticBranchOutDistance { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<SoundPatchAsset> VOPlayback { get; set; }

		[FieldOffset(24, 56)]
		public QualityScalableInt VoBufferStreamCount { get; set; }

		[FieldOffset(40, 72)]
		public QualityScalableInt VoMaxStreamCount { get; set; }

		[FieldOffset(56, 88)]
		public ConversationInterruptionType InterruptsOthers { get; set; }

		[FieldOffset(60, 92)]
		public ConversationInterruptionType BlocksOthers { get; set; }

		[FieldOffset(64, 96)]
		public int GuiPriority { get; set; }

		[FieldOffset(68, 100)]
		public float WaitForStreamingMovementThreshold { get; set; }

		[FieldOffset(72, 104)]
		public float WaitForStreamingMovementSkipTimeWindow { get; set; }

		[FieldOffset(76, 112)]
		public ExternalObject<FadeOutWhenConversationNotStreamedInOnPlay> NotStreamedInOnStartBehavior { get; set; }

		[FieldOffset(80, 120)]
		public uint FreezeFramesOnEnter { get; set; }

		[FieldOffset(84, 124)]
		public uint FreezeFramesOnExit { get; set; }

		[FieldOffset(88, 128)]
		public PlotConditionReference EnabledCondition { get; set; }

		[FieldOffset(116, 208)]
		public List<bool> CustomFlagValues { get; set; }

		[FieldOffset(120, 216)]
		public string DebugDisplayName { get; set; }

		[FieldOffset(124, 224)]
		public bool SpeechOnly { get; set; }

		[FieldOffset(125, 225)]
		public bool UseAutoLookAt { get; set; }

		[FieldOffset(126, 226)]
		public bool EnsureListenerObjectTrack { get; set; }

		[FieldOffset(127, 227)]
		public bool SynchronizeExit { get; set; }

		[FieldOffset(128, 228)]
		public bool LockInputBetweenStartAndFirstLine { get; set; }

		[FieldOffset(129, 229)]
		public bool AlwaysUseChooserUI { get; set; }

		[FieldOffset(130, 230)]
		public bool AllowChangingMovementControlState { get; set; }

		[FieldOffset(131, 231)]
		public bool InitialMovementControlState { get; set; }

		[FieldOffset(132, 232)]
		public bool DisableOptInIfNoChoicesInFuture { get; set; }

		[FieldOffset(133, 233)]
		public bool UseCreatureInteractionForOptIn { get; set; }

		[FieldOffset(134, 234)]
		public bool ShowSubtitles { get; set; }

		[FieldOffset(135, 235)]
		public bool ForceShowSubtitles { get; set; }

		[FieldOffset(136, 236)]
		public bool AutomaticBranchOut { get; set; }

		[FieldOffset(137, 237)]
		public bool IsExclusive { get; set; }

		[FieldOffset(138, 238)]
		public QualityScalableBool PreStreamTimelineData { get; set; }

		[FieldOffset(142, 242)]
		public QualityScalableBool VoBufferOnPrestream { get; set; }

		[FieldOffset(146, 246)]
		public bool RequiresSeamlessCutBetweenConversations { get; set; }

		[FieldOffset(147, 247)]
		public bool UsePredictiveStreaming { get; set; }

		[FieldOffset(148, 248)]
		public QualityScalableBool WarnIfNotStreamedInOnStart { get; set; }

		[FieldOffset(152, 252)]
		public bool DisableCulling { get; set; }

		[FieldOffset(153, 253)]
		public bool HideUnusedPartyMembers { get; set; }

		[FieldOffset(154, 254)]
		public bool BlockSaving { get; set; }

		public ConversationTypeSettings()
		{
			CustomFlagValues = new List<bool>();
		}
	}
}

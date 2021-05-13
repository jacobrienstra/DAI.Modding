using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ConversationEntityData : LocalizedStringContainerEntityData
	{
		[FieldOffset(80, 176)]
		public Vec3 PredictiveStreamingPositionOverride { get; set; }

		[FieldOffset(96, 192)]
		public ExternalObject<Conversation> Conversation { get; set; }

		[FieldOffset(100, 200)]
		public ConversationStreamingBehavior StreamingBehavior { get; set; }

		[FieldOffset(104, 208)]
		public ExternalObject<ConversationNotStreamedInOnStartBehavior> NotStreamedInOnStartBehaviorOverride { get; set; }

		[FieldOffset(108, 216)]
		public ConversationFreezeFrames FreezeFramesOnEnter { get; set; }

		[FieldOffset(112, 220)]
		public ConversationFreezeFrames FreezeFramesOnExit { get; set; }

		[FieldOffset(116, 224)]
		public int SubLevelStreamingActivatorCategoryToFreeze { get; set; }

		[FieldOffset(120, 232)]
		public List<ExternalObject<Dummy>> CharacterBindings { get; set; }

		[FieldOffset(124, 240)]
		public ConversationInterruptionType InterruptsOthers { get; set; }

		[FieldOffset(128, 244)]
		public float AutomaticBranchOutDistanceOverride { get; set; }

		[FieldOffset(132, 248)]
		public ExternalObject<Dummy> ExtraDLCData { get; set; }

		[FieldOffset(136, 256)]
		public BlueprintBundleReference TimelinesBundle { get; set; }

		[FieldOffset(164, 344)]
		public BlueprintBundleReference FirstLineAnimationsBundle { get; set; }

		[FieldOffset(192, 432)]
		public BlueprintBundleReference FollowingLineAnimationsBundle { get; set; }

		[FieldOffset(220, 520)]
		public List<FaceFXAnimationsBundle> FirstLineFaceFXBundles { get; set; }

		[FieldOffset(224, 528)]
		public List<FaceFXAnimationsBundle> FollowingLineFaceFXBundles { get; set; }

		[FieldOffset(228, 536)]
		public List<ExternalObject<GameObjectData>> NonStandardVOStringFirstLines { get; set; }

		[FieldOffset(232, 544)]
		public List<PlotFlagId> FirstLineTimelineTrackConditionFlags { get; set; }

		[FieldOffset(236, 552)]
		public List<ExternalObject<DataContainer>> VoiceOverBindings { get; set; }

		[FieldOffset(240, 560)]
		public List<ExternalObject<EntityData>> TextToSpeechBindings { get; set; }

		[FieldOffset(244, 568)]
		public uint ConversationEntityId { get; set; }

		[FieldOffset(248, 576)]
		public List<int> PinnedCharacterIds { get; set; }

		[FieldOffset(252, 584)]
		public QualityScalableBool NeverStreamInEarly { get; set; }

		[FieldOffset(256, 588)]
		public bool DontWarnIfNotStreamedInOnStart { get; set; }

		[FieldOffset(257, 589)]
		public bool DisablePostConversationFade { get; set; }

		[FieldOffset(258, 590)]
		public bool DisablePredictiveStreaming { get; set; }

		[FieldOffset(259, 591)]
		public bool FreezeFrameOnEnterASAP { get; set; }

		[FieldOffset(260, 592)]
		public bool FreezeSubLevelStreamingActivators { get; set; }

		[FieldOffset(261, 593)]
		public bool CreateSubLevelStreamingTriggerActivatorsAtStart { get; set; }

		[FieldOffset(262, 594)]
		public bool FreezeZoneStreaming { get; set; }

		[FieldOffset(263, 595)]
		public bool ZoneStreamingFollowsCamera { get; set; }

		[FieldOffset(264, 596)]
		public bool DebugModeEnabled { get; set; }

		[FieldOffset(265, 597)]
		public bool DummyCamerasGenerated { get; set; }

		[FieldOffset(266, 598)]
		public bool UseTimelineSpawner { get; set; }

		[FieldOffset(267, 599)]
		public bool ForceOptInOnStart { get; set; }

		public ConversationEntityData()
		{
			CharacterBindings = new List<ExternalObject<Dummy>>();
			FirstLineFaceFXBundles = new List<FaceFXAnimationsBundle>();
			FollowingLineFaceFXBundles = new List<FaceFXAnimationsBundle>();
			NonStandardVOStringFirstLines = new List<ExternalObject<GameObjectData>>();
			FirstLineTimelineTrackConditionFlags = new List<PlotFlagId>();
			VoiceOverBindings = new List<ExternalObject<DataContainer>>();
			TextToSpeechBindings = new List<ExternalObject<EntityData>>();
			PinnedCharacterIds = new List<int>();
		}
	}
}

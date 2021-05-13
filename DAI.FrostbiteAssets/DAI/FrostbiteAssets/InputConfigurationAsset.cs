using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InputConfigurationAsset : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<EntryInputActionMapsData> DefaultInputConceptDefinition { get; set; }

		[FieldOffset(16, 80)]
		public List<InputConceptIdentifiers> DefaultExclusiveInputConcepts { get; set; }

		[FieldOffset(20, 88)]
		public ExternalObject<EntryInputActionBindingsData> EntryInputActionBindings { get; set; }

		[FieldOffset(24, 96)]
		public List<EditableActionMap> UserConfigurableActionMaps { get; set; }

		[FieldOffset(28, 104)]
		public ExternalObject<UIInputActionDataAsset> UIInputActions { get; set; }

		[FieldOffset(32, 112)]
		public int TogglePoseAction { get; set; }

		[FieldOffset(36, 116)]
		public int CrouchAction { get; set; }

		[FieldOffset(40, 120)]
		public int CrouchAndHoldAction { get; set; }

		[FieldOffset(44, 124)]
		public int PickupInteractionAction { get; set; }

		[FieldOffset(48, 128)]
		public int PickupInteractionActionKeyboard { get; set; }

		[FieldOffset(52, 132)]
		public float SprintReleaseTime { get; set; }

		[FieldOffset(56, 136)]
		public float ThrottleInputRequiredForSprint { get; set; }

		[FieldOffset(60, 140)]
		public float VehicleBoostIsToggleMinInput { get; set; }

		[FieldOffset(64, 144)]
		public float EnterVehicleHoldTime { get; set; }

		[FieldOffset(68, 152)]
		public List<PoseTransition> FiringDisablingTransitions { get; set; }

		[FieldOffset(72, 160)]
		public bool ReverseInputConceptExclusion { get; set; }

		[FieldOffset(73, 161)]
		public bool ProneToStandOnJump { get; set; }

		[FieldOffset(74, 162)]
		public bool StandAutomaticallyIfSprinting { get; set; }

		[FieldOffset(75, 163)]
		public bool DisableCrouch { get; set; }

		[FieldOffset(76, 164)]
		public bool DisableProne { get; set; }

		[FieldOffset(77, 165)]
		public bool DisableCrawlingWhileFiring { get; set; }

		[FieldOffset(78, 166)]
		public bool DisableCrawlingWhileReloading { get; set; }

		[FieldOffset(79, 167)]
		public bool DisableFiringWhileDeployingBipod { get; set; }

		[FieldOffset(80, 168)]
		public bool DisableFiringWhileJumping { get; set; }

		[FieldOffset(81, 169)]
		public bool DisableSprintingWhileReloading { get; set; }

		[FieldOffset(82, 170)]
		public bool EnableSprintToCrouchTransition { get; set; }

		[FieldOffset(83, 171)]
		public bool StopSprintingWhenReleasingThrottle { get; set; }

		[FieldOffset(84, 172)]
		public bool StopSprintingWhenReleasingSprint { get; set; }

		[FieldOffset(85, 173)]
		public bool WaitForSprintReleaseBeforeSprintAgain { get; set; }

		[FieldOffset(86, 174)]
		public bool VehicleBoostIsToggle { get; set; }

		[FieldOffset(87, 175)]
		public bool InputCurvesEnabled { get; set; }

		public InputConfigurationAsset()
		{
			DefaultExclusiveInputConcepts = new List<InputConceptIdentifiers>();
			UserConfigurableActionMaps = new List<EditableActionMap>();
			FiringDisablingTransitions = new List<PoseTransition>();
		}
	}
}

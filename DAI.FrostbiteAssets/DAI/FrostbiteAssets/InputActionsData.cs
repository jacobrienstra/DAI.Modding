using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InputActionsData : DataContainer
	{
		[FieldOffset(8, 24)]
		public string NameSid { get; set; }

		[FieldOffset(12, 32)]
		public InputConceptIdentifiers ConceptIdentifier { get; set; }

		[FieldOffset(16, 36)]
		public InputConceptIdentifiers CopyKeyBindingFrom { get; set; }

		[FieldOffset(20, 40)]
		public KeyBindingConstraint BindingConstraint { get; set; }

		[FieldOffset(24, 48)]
		public List<KeyBindingGroup> BindingGroups { get; set; }

		[FieldOffset(28, 56)]
		public InputNegationRequirement CopyNegatedKeyBinding { get; set; }

		[FieldOffset(32, 64)]
		public List<ExternalObject<EntryInputActionMapData>> InputActions { get; set; }

		[FieldOffset(36, 72)]
		public bool HideInKeyBindings { get; set; }

		[FieldOffset(37, 73)]
		public bool PrioritizeNegatedAction { get; set; }

		public InputActionsData()
		{
			BindingGroups = new List<KeyBindingGroup>();
			InputActions = new List<ExternalObject<EntryInputActionMapData>>();
		}
	}
}

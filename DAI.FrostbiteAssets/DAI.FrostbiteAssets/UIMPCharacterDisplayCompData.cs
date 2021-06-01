using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIMPCharacterDisplayCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public int DuelistArchetypeID { get; set; }

		[FieldOffset(36, 144)]
		public ExternalObject<BWDepletableStat> DuelistElusiveCountStat { get; set; }

		[FieldOffset(40, 152)]
		public ExternalObject<BWModifiableStat> DuelistElusiveMaxStat { get; set; }

		[FieldOffset(44, 160)]
		public float DuelistElusiveIconMaxRotationDegrees { get; set; }

		[FieldOffset(48, 164)]
		public int AvvarArchetypeID { get; set; }

		[FieldOffset(52, 168)]
		public ExternalObject<BWModifiableStat> AvvarElementStat { get; set; }

		[FieldOffset(56, 176)]
		public int BardArchetypeID { get; set; }

		[FieldOffset(60, 184)]
		public ExternalObject<BWModifiableStat> BardNotesPlayedStat { get; set; }

		[FieldOffset(64, 192)]
		public ExternalObject<BWModifiableStat> BardChordCodeStat { get; set; }

		[FieldOffset(68, 200)]
		public List<MPBardAbilityInfo> BardNoteInfos { get; set; }

		[FieldOffset(72, 208)]
		public List<MPBardAbilityInfo> BardChordInfos { get; set; }

		[FieldOffset(76, 216)]
		public ExternalObject<BWActivatedAbility> BardInvalidSongAbility { get; set; }

		public UIMPCharacterDisplayCompData()
		{
			BardNoteInfos = new List<MPBardAbilityInfo>();
			BardChordInfos = new List<MPBardAbilityInfo>();
		}
	}
}

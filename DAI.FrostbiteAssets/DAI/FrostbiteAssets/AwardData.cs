using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AwardData : AbstractAwardData
	{
		[FieldOffset(8, 48)]
		public List<ExternalObject<Dummy>> FilteredChildAwards { get; set; }

		[FieldOffset(12, 56)]
		public uint CriteriaCompletionValueTotal { get; set; }

		[FieldOffset(16, 64)]
		public List<ExternalObject<AwardAchievementData>> Criteria { get; set; }

		[FieldOffset(20, 72)]
		public string Code { get; set; }

		[FieldOffset(24, 80)]
		public LocalizedStringReference LocalizedDescription { get; set; }

		[FieldOffset(28, 104)]
		public LocalizedStringReference LocalizedName { get; set; }

		[FieldOffset(32, 128)]
		public AwardKitAssociation KitAssociation { get; set; }

		[FieldOffset(36, 136)]
		public string ImageName { get; set; }

		[FieldOffset(40, 144)]
		public string ImageSmallName { get; set; }

		[FieldOffset(44, 152)]
		public string ImageFancyName { get; set; }

		[FieldOffset(48, 160)]
		public string SoundName { get; set; }

		[FieldOffset(52, 168)]
		public AwardType Repeat { get; set; }

		[FieldOffset(56, 172)]
		public uint MaxRepetitions { get; set; }

		[FieldOffset(60, 176)]
		public List<CriteriaAward> Dependencies { get; set; }

		[FieldOffset(64, 184)]
		public AwardGroup Group { get; set; }

		[FieldOffset(68, 188)]
		public StatsMultiplicity Multiplicity { get; set; }

		[FieldOffset(72, 192)]
		public ExternalObject<Dummy> ParentAward { get; set; }

		[FieldOffset(76, 200)]
		public float Score { get; set; }

		[FieldOffset(80, 204)]
		public ScoringBucket Bucket { get; set; }

		[FieldOffset(84, 208)]
		public List<BasicUnlockInfo> UnlockInfos { get; set; }

		[FieldOffset(88, 216)]
		public ExternalObject<Dummy> UnlockGates { get; set; }

		[FieldOffset(92, 224)]
		public int DLCPackage { get; set; }

		[FieldOffset(96, 228)]
		public bool Visible { get; set; }

		[FieldOffset(97, 229)]
		public bool ActiveOnCreation { get; set; }

		public AwardData()
		{
			FilteredChildAwards = new List<ExternalObject<Dummy>>();
			Criteria = new List<ExternalObject<AwardAchievementData>>();
			Dependencies = new List<CriteriaAward>();
			UnlockInfos = new List<BasicUnlockInfo>();
		}
	}
}

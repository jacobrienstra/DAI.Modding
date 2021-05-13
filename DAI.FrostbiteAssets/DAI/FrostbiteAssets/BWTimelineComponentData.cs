using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWTimelineComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public Realm Realm { get; set; }

		[FieldOffset(100, 184)]
		public ExternalObject<DefensiveCollisionList> DefensiveCollisions { get; set; }

		[FieldOffset(104, 192)]
		public List<ExternalObject<DataContainer>> CollisionDefinitions { get; set; }

		[FieldOffset(108, 200)]
		public MaterialDecl ReceiverMaterialPair { get; set; }

		[FieldOffset(112, 216)]
		public MaterialDecl ArmoredMaterialPair { get; set; }

		[FieldOffset(116, 232)]
		public MaterialDecl BarrierMaterialPair { get; set; }

		[FieldOffset(120, 248)]
		public MaterialDecl DefaultCriticalHitMaterialPair { get; set; }

		[FieldOffset(124, 264)]
		public List<string> InputEvents { get; set; }

		[FieldOffset(128, 272)]
		public List<string> OutputEvents { get; set; }

		[FieldOffset(132, 280)]
		public ExternalObject<BWTimelineAliasMap> TimelineAliasMap { get; set; }

		[FieldOffset(136, 288)]
		public uint DefaultDisabledDefensiveLayers { get; set; }

		public BWTimelineComponentData()
		{
			CollisionDefinitions = new List<ExternalObject<DataContainer>>();
			InputEvents = new List<string>();
			OutputEvents = new List<string>();
		}
	}
}

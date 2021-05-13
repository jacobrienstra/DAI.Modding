using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SchematicChannelEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public ExternalObject<SchematicChannelAsset> Channel { get; set; }

		[FieldOffset(24, 112)]
		public List<Dummy> InputProperties { get; set; }

		[FieldOffset(28, 120)]
		public List<Dummy> InputRefProperties { get; set; }

		[FieldOffset(32, 128)]
		public List<Dummy> OutputProperties { get; set; }

		[FieldOffset(36, 136)]
		public List<Dummy> OutputRefProperties { get; set; }

		public SchematicChannelEntityData()
		{
			InputProperties = new List<Dummy>();
			InputRefProperties = new List<Dummy>();
			OutputProperties = new List<Dummy>();
			OutputRefProperties = new List<Dummy>();
		}
	}
}

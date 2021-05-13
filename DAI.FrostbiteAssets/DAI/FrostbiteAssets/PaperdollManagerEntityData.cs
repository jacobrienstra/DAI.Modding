namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PaperdollManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform PaperdollTransform { get; set; }

		[FieldOffset(80, 160)]
		public ExternalObject<SpatialPrefabBlueprint> PaperdollPrefab { get; set; }

		[FieldOffset(84, 168)]
		public uint NameHash { get; set; }
	}
}

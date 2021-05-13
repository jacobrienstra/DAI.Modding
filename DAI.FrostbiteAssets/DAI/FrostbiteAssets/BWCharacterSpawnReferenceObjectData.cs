namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCharacterSpawnReferenceObjectData : CharacterSpawnReferenceObjectData
	{
		[FieldOffset(384, 544)]
		public uint BlueprintBundleHash { get; set; }

		[FieldOffset(388, 548)]
		public int BlueprintBundleStreamingScatterContentManagedCategory { get; set; }

		[FieldOffset(392, 552)]
		public ExternalObject<Dummy> CreatureProfile { get; set; }
	}
}

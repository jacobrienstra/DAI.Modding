namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class FaceFXAsset : Asset
	{
		[FieldOffset(12, 72)]
		public string ActorShortName { get; set; }

		[FieldOffset(16, 80)]
		public long ActorData { get; set; }

		[FieldOffset(24, 88)]
		public long BonesetData { get; set; }
	}
}

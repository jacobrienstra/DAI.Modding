namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OnDemandTextureInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint AssetNameHash { get; set; }

		[FieldOffset(4, 8)]
		public string AssetPath { get; set; }
	}
}

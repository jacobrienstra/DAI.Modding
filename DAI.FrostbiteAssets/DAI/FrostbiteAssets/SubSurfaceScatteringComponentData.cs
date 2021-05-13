using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SubSurfaceScatteringComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 SimpleSssColor { get; set; }

		[FieldOffset(128, 208)]
		public Vec3 AdvancedSssMat0Width { get; set; }

		[FieldOffset(144, 224)]
		public Vec3 AdvancedSssMat1Width { get; set; }

		[FieldOffset(160, 240)]
		public Vec3 AdvancedSssMat2Width { get; set; }

		[FieldOffset(176, 256)]
		public Vec3 AdvancedSssMat3Width { get; set; }

		[FieldOffset(192, 272)]
		public Vec3 AdvancedSssMat4Width { get; set; }

		[FieldOffset(208, 288)]
		public Realm Realm { get; set; }

		[FieldOffset(212, 292)]
		public float SimpleSssRolloffKeyLight { get; set; }

		[FieldOffset(216, 296)]
		public float SimpleSssRolloffLocalLight { get; set; }

		[FieldOffset(220, 300)]
		public bool AdvancedSssEnable { get; set; }
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class MorphStatic : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<SkinnedMeshAsset> RuntimeHeadBase { get; set; }

		[FieldOffset(16, 80)]
		public long MorphResource { get; set; }

		[FieldOffset(24, 88)]
		public long MorphMaterialResource { get; set; }

		[FieldOffset(32, 96)]
		public ExternalObject<SkinnedMeshAsset> RuntimeHair { get; set; }

		[FieldOffset(36, 104)]
		public ExternalObject<SkinnedMeshAsset> RuntimeBeard { get; set; }

		[FieldOffset(40, 112)]
		public ExternalObject<MeshAsset> RuntimeHorns { get; set; }

		[FieldOffset(44, 120)]
		public int SelectedPresetIndex { get; set; }

		[FieldOffset(48, 128)]
		public List<VariationLink> VariationLinks { get; set; }

		[FieldOffset(52, 136)]
		public List<ExternalObject<Vec4ShaderParameter>> SliderParameters { get; set; }

		[FieldOffset(56, 144)]
		public List<ExternalObject<Vec4ShaderParameter>> ChannelParameters { get; set; }

		[FieldOffset(60, 152)]
		public List<ExternalObject<Vec4ShaderParameter>> ColorParameters { get; set; }

		[FieldOffset(64, 160)]
		public List<ExternalObject<ShaderParameter>> TextureParameters { get; set; }

		public MorphStatic()
		{
			VariationLinks = new List<VariationLink>();
			SliderParameters = new List<ExternalObject<Vec4ShaderParameter>>();
			ChannelParameters = new List<ExternalObject<Vec4ShaderParameter>>();
			ColorParameters = new List<ExternalObject<Vec4ShaderParameter>>();
			TextureParameters = new List<ExternalObject<ShaderParameter>>();
		}
	}
}

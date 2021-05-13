using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class MorphTargets : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<MorphPreset>> Presets { get; set; }

		[FieldOffset(16, 80)]
		public long MorphTargetsResource { get; set; }

		[FieldOffset(24, 88)]
		public ExternalObject<MorphShapes> Shapes { get; set; }

		[FieldOffset(28, 96)]
		public ExternalObject<MorphSliders> FeatureBlends { get; set; }

		[FieldOffset(32, 104)]
		public List<ExternalObject<MorphPreset>> HeadMeshAssets { get; set; }

		[FieldOffset(36, 112)]
		public List<ExternalObject<MorphPreset>> HairMeshAssets { get; set; }

		[FieldOffset(40, 120)]
		public List<ExternalObject<MorphPreset>> BeardMeshAssets { get; set; }

		[FieldOffset(44, 128)]
		public List<ExternalObject<MorphPreset>> HornMeshAssets { get; set; }

		[FieldOffset(48, 136)]
		public List<ExternalObject<MorphPreset>> SliderShaderParameterTemplates { get; set; }

		[FieldOffset(52, 144)]
		public List<ExternalObject<MorphPreset>> ChannelShaderParameterTemplates { get; set; }

		[FieldOffset(56, 152)]
		public List<ExternalObject<MorphPreset>> ColorShaderParameterTemplates { get; set; }

		[FieldOffset(60, 160)]
		public List<ExternalObject<MorphPreset>> TextureShaderParameterTemplates { get; set; }

		[FieldOffset(64, 168)]
		public float EditorVerticalOffset { get; set; }

		[FieldOffset(68, 172)]
		public bool DisableAdditiveBoneOffsets { get; set; }

		public MorphTargets()
		{
			Presets = new List<ExternalObject<MorphPreset>>();
			HeadMeshAssets = new List<ExternalObject<MorphPreset>>();
			HairMeshAssets = new List<ExternalObject<MorphPreset>>();
			BeardMeshAssets = new List<ExternalObject<MorphPreset>>();
			HornMeshAssets = new List<ExternalObject<MorphPreset>>();
			SliderShaderParameterTemplates = new List<ExternalObject<MorphPreset>>();
			ChannelShaderParameterTemplates = new List<ExternalObject<MorphPreset>>();
			ColorShaderParameterTemplates = new List<ExternalObject<MorphPreset>>();
			TextureShaderParameterTemplates = new List<ExternalObject<MorphPreset>>();
		}
	}
}

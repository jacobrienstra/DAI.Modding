using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FaceCustomizationData : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<FaceCustomizationBlendData> BlendData { get; set; }

		[FieldOffset(4, 8)]
		public List<FaceCustomizationVectorData> VectorData { get; set; }

		[FieldOffset(8, 16)]
		public List<FaceCustomizationTextureData> TextureData { get; set; }

		[FieldOffset(12, 24)]
		public List<FaceCustomizationVoiceData> VoiceData { get; set; }

		[FieldOffset(16, 32)]
		public List<FaceCustomizationUniqueShapeData> ShapeData { get; set; }

		[FieldOffset(20, 40)]
		public List<FaceCustomizationPresetData> PresetData { get; set; }

		[FieldOffset(24, 48)]
		public List<FaceCustomizationStyleData> StyleData { get; set; }

		[FieldOffset(28, 56)]
		public ExternalObject<Dummy> PresetIcon { get; set; }

		[FieldOffset(32, 64)]
		public uint Version { get; set; }

		public FaceCustomizationData()
		{
			BlendData = new List<FaceCustomizationBlendData>();
			VectorData = new List<FaceCustomizationVectorData>();
			TextureData = new List<FaceCustomizationTextureData>();
			VoiceData = new List<FaceCustomizationVoiceData>();
			ShapeData = new List<FaceCustomizationUniqueShapeData>();
			PresetData = new List<FaceCustomizationPresetData>();
			StyleData = new List<FaceCustomizationStyleData>();
		}
	}
}

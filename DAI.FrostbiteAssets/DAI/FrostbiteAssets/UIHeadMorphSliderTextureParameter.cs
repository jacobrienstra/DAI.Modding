using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeadMorphSliderTextureParameter : UIHeadMorphSliderShaderParameter
	{
		[FieldOffset(32, 96)]
		public List<ExternalObject<LogicPrefabReferenceObjectData>> Textures { get; set; }

		public UIHeadMorphSliderTextureParameter()
		{
			Textures = new List<ExternalObject<LogicPrefabReferenceObjectData>>();
		}
	}
}

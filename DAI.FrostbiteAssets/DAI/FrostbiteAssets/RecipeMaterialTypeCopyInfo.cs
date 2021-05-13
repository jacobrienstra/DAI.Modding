using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RecipeMaterialTypeCopyInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public RecipeMaterialTypes MaterialType { get; set; }

		[FieldOffset(4, 8)]
		public List<RecipeMaterialParamCopyInfo> ParamData { get; set; }

		[FieldOffset(8, 16)]
		public List<string> TextureData { get; set; }

		public RecipeMaterialTypeCopyInfo()
		{
			ParamData = new List<RecipeMaterialParamCopyInfo>();
			TextureData = new List<string>();
		}
	}
}

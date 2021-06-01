using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DifficultyMode : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public int DifficultyModeID { get; set; }

		[FieldOffset(16, 80)]
		public List<DifficultyFloatMapping> FloatMapping { get; set; }

		[FieldOffset(20, 88)]
		public List<DifficultyBoolMapping> BoolMapping { get; set; }

		public DifficultyMode()
		{
			FloatMapping = new List<DifficultyFloatMapping>();
			BoolMapping = new List<DifficultyBoolMapping>();
		}
	}
}

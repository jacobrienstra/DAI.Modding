using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class AppearanceComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public AppearanceCustomizations AppearanceCustomizations { get; set; }

		[FieldOffset(108, 200)]
		public AntRef MorphBoneControllerPointer { get; set; }

		[FieldOffset(128, 248)]
		public List<ExternalObject<DataContainer>> MeshSets { get; set; }

		[FieldOffset(132, 256)]
		public bool MotionBlurEnable { get; set; }

		public AppearanceComponentData()
		{
			MeshSets = new List<ExternalObject<DataContainer>>();
		}
	}
}

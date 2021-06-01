using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BuilderAppearanceComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<MorphTargets> Morphs { get; set; }

		[FieldOffset(100, 184)]
		public List<ExternalObject<Dummy>> MeshSets { get; set; }

		[FieldOffset(104, 192)]
		public int HeadOverrideId { get; set; }

		public BuilderAppearanceComponentData()
		{
			MeshSets = new List<ExternalObject<Dummy>>();
		}
	}
}

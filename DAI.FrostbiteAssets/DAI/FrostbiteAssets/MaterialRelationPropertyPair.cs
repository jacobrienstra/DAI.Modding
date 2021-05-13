using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialRelationPropertyPair : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<ExternalObject<MaterialPropertySoundData>> PhysicsMaterialProperties { get; set; }

		[FieldOffset(4, 8)]
		public List<ExternalObject<MaterialPropertySoundData>> PhysicsPropertyProperties { get; set; }

		public MaterialRelationPropertyPair()
		{
			PhysicsMaterialProperties = new List<ExternalObject<MaterialPropertySoundData>>();
			PhysicsPropertyProperties = new List<ExternalObject<MaterialPropertySoundData>>();
		}
	}
}

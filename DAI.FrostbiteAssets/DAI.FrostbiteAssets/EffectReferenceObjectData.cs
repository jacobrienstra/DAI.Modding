using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EffectReferenceObjectData : SpatialReferenceObjectData
	{
		[FieldOffset(112, 256)]
		public List<ExternalObject<GameObjectData>> EffectParameters { get; set; }

		[FieldOffset(116, 264)]
		public bool AutoStart { get; set; }

		[FieldOffset(117, 265)]
		public bool AffectedByLightprobeVisibility { get; set; }

		public EffectReferenceObjectData()
		{
			EffectParameters = new List<ExternalObject<GameObjectData>>();
		}
	}
}

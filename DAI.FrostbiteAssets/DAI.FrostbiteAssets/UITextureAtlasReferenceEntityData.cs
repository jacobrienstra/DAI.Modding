using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITextureAtlasReferenceEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<Dummy>> RemoteAtlases { get; set; }

		[FieldOffset(20, 104)]
		public List<ExternalObject<GameObjectData>> Atlases { get; set; }

		public UITextureAtlasReferenceEntityData()
		{
			RemoteAtlases = new List<ExternalObject<Dummy>>();
			Atlases = new List<ExternalObject<GameObjectData>>();
		}
	}
}

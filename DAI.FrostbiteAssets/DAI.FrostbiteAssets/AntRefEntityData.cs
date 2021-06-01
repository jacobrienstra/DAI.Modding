using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AntRefEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<AntRef> Actors { get; set; }

		[FieldOffset(20, 104)]
		public List<AntRef> Controllers { get; set; }

		[FieldOffset(24, 112)]
		public List<AntRef> SceneOpMatrix { get; set; }

		public AntRefEntityData()
		{
			Actors = new List<AntRef>();
			Controllers = new List<AntRef>();
			SceneOpMatrix = new List<AntRef>();
		}
	}
}

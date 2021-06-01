using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIActionEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int ActionKey { get; set; }

		[FieldOffset(20, 104)]
		public List<string> Params { get; set; }

		[FieldOffset(24, 112)]
		public ExternalObject<Dummy> ActionAsset { get; set; }

		[FieldOffset(28, 120)]
		public List<Dummy> PropertyParams { get; set; }

		public UIActionEntityData()
		{
			Params = new List<string>();
			PropertyParams = new List<Dummy>();
		}
	}
}

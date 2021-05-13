using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICoopCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public UITextureAtlasTextureReference defaultBannerImage { get; set; }

		[FieldOffset(52, 176)]
		public UITextureAtlasTextureReference defaultAccomplishmentIcon { get; set; }

		[FieldOffset(72, 216)]
		public UITextureAtlasTextureReference defaultItemIcon { get; set; }

		[FieldOffset(92, 256)]
		public ExternalObject<Dummy> MatchEndParchmentSuccessImage { get; set; }

		[FieldOffset(96, 264)]
		public ExternalObject<TextureAsset> MatchEndParchmentFailureImage { get; set; }

		[FieldOffset(100, 272)]
		public List<UIMultiplayerArchetypeTextureData> MultiplayerArchetypeLockedTextures { get; set; }

		[FieldOffset(104, 280)]
		public float MatchCountdownTimeOfNoReturn { get; set; }

		public UICoopCompData()
		{
			MultiplayerArchetypeLockedTextures = new List<UIMultiplayerArchetypeTextureData>();
		}
	}
}

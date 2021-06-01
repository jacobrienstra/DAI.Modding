using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWMap : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public int ID { get; set; }

		[FieldOffset(16, 80)]
		public BWMapBoundingVolume OuterBound { get; set; }

		[FieldOffset(48, 112)]
		public int Orientation { get; set; }

		[FieldOffset(52, 120)]
		public LocalizedStringReference TitleReference { get; set; }

		[FieldOffset(56, 144)]
		public string TextureName { get; set; }

		[FieldOffset(60, 152)]
		public int TextureWidth { get; set; }

		[FieldOffset(64, 156)]
		public int TextureHeight { get; set; }

		[FieldOffset(68, 160)]
		public List<BWMapBoundingVolume> InnerBounds { get; set; }

		[FieldOffset(72, 168)]
		public ExternalObject<BWMap> ZoomOutMap { get; set; }

		[FieldOffset(76, 176)]
		public string LevelName { get; set; }

		[FieldOffset(80, 184)]
		public List<ExternalObject<BWMapPin>> MapPins { get; set; }

		[FieldOffset(84, 192)]
		public ExternalObject<BWMapGroup> Group { get; set; }

		[FieldOffset(88, 200)]
		public BWMapFogType FogOfWar { get; set; }

		[FieldOffset(92, 204)]
		public float FogRevealRadius { get; set; }

		[FieldOffset(96, 208)]
		public bool ShowOnFloorStack { get; set; }

		public BWMap()
		{
			InnerBounds = new List<BWMapBoundingVolume>();
			MapPins = new List<ExternalObject<BWMapPin>>();
		}
	}
}

using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SunFlareComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec4 Element1SizeOccluderCurve { get; set; }

		[FieldOffset(128, 208)]
		public Vec4 Element1SizeScreenPosCurve { get; set; }

		[FieldOffset(144, 224)]
		public Vec4 Element1AlphaOccluderCurve { get; set; }

		[FieldOffset(160, 240)]
		public Vec4 Element1AlphaScreenPosCurve { get; set; }

		[FieldOffset(176, 256)]
		public Vec4 Element1RotationDistCurve { get; set; }

		[FieldOffset(192, 272)]
		public Vec4 Element2SizeOccluderCurve { get; set; }

		[FieldOffset(208, 288)]
		public Vec4 Element2SizeScreenPosCurve { get; set; }

		[FieldOffset(224, 304)]
		public Vec4 Element2AlphaOccluderCurve { get; set; }

		[FieldOffset(240, 320)]
		public Vec4 Element2AlphaScreenPosCurve { get; set; }

		[FieldOffset(256, 336)]
		public Vec4 Element2RotationDistCurve { get; set; }

		[FieldOffset(272, 352)]
		public Vec4 Element3SizeOccluderCurve { get; set; }

		[FieldOffset(288, 368)]
		public Vec4 Element3SizeScreenPosCurve { get; set; }

		[FieldOffset(304, 384)]
		public Vec4 Element3AlphaOccluderCurve { get; set; }

		[FieldOffset(320, 400)]
		public Vec4 Element3AlphaScreenPosCurve { get; set; }

		[FieldOffset(336, 416)]
		public Vec4 Element3RotationDistCurve { get; set; }

		[FieldOffset(352, 432)]
		public Vec4 Element4SizeOccluderCurve { get; set; }

		[FieldOffset(368, 448)]
		public Vec4 Element4SizeScreenPosCurve { get; set; }

		[FieldOffset(384, 464)]
		public Vec4 Element4AlphaOccluderCurve { get; set; }

		[FieldOffset(400, 480)]
		public Vec4 Element4AlphaScreenPosCurve { get; set; }

		[FieldOffset(416, 496)]
		public Vec4 Element4RotationDistCurve { get; set; }

		[FieldOffset(432, 512)]
		public Vec4 Element5SizeOccluderCurve { get; set; }

		[FieldOffset(448, 528)]
		public Vec4 Element5SizeScreenPosCurve { get; set; }

		[FieldOffset(464, 544)]
		public Vec4 Element5AlphaOccluderCurve { get; set; }

		[FieldOffset(480, 560)]
		public Vec4 Element5AlphaScreenPosCurve { get; set; }

		[FieldOffset(496, 576)]
		public Vec4 Element5RotationDistCurve { get; set; }

		[FieldOffset(512, 592)]
		public Realm Realm { get; set; }

		[FieldOffset(516, 596)]
		public float OccluderSize { get; set; }

		[FieldOffset(520, 600)]
		public ExternalObject<ShaderGraph> Element1Shader { get; set; }

		[FieldOffset(524, 608)]
		public float Element1RayDistance { get; set; }

		[FieldOffset(528, 612)]
		public Vec2 Element1Size { get; set; }

		[FieldOffset(536, 620)]
		public float Element1RotationLocal { get; set; }

		[FieldOffset(540, 624)]
		public float Element1RotationDistMultiplier { get; set; }

		[FieldOffset(544, 632)]
		public ExternalObject<ShaderGraph> Element2Shader { get; set; }

		[FieldOffset(548, 640)]
		public float Element2RayDistance { get; set; }

		[FieldOffset(552, 644)]
		public Vec2 Element2Size { get; set; }

		[FieldOffset(560, 652)]
		public float Element2RotationLocal { get; set; }

		[FieldOffset(564, 656)]
		public float Element2RotationDistMultiplier { get; set; }

		[FieldOffset(568, 664)]
		public ExternalObject<ShaderGraph> Element3Shader { get; set; }

		[FieldOffset(572, 672)]
		public float Element3RayDistance { get; set; }

		[FieldOffset(576, 676)]
		public Vec2 Element3Size { get; set; }

		[FieldOffset(584, 684)]
		public float Element3RotationLocal { get; set; }

		[FieldOffset(588, 688)]
		public float Element3RotationDistMultiplier { get; set; }

		[FieldOffset(592, 696)]
		public ExternalObject<ShaderGraph> Element4Shader { get; set; }

		[FieldOffset(596, 704)]
		public float Element4RayDistance { get; set; }

		[FieldOffset(600, 708)]
		public Vec2 Element4Size { get; set; }

		[FieldOffset(608, 716)]
		public float Element4RotationLocal { get; set; }

		[FieldOffset(612, 720)]
		public float Element4RotationDistMultiplier { get; set; }

		[FieldOffset(616, 728)]
		public ExternalObject<ShaderGraph> Element5Shader { get; set; }

		[FieldOffset(620, 736)]
		public float Element5RayDistance { get; set; }

		[FieldOffset(624, 740)]
		public Vec2 Element5Size { get; set; }

		[FieldOffset(632, 748)]
		public float Element5RotationLocal { get; set; }

		[FieldOffset(636, 752)]
		public float Element5RotationDistMultiplier { get; set; }

		[FieldOffset(640, 756)]
		public bool Enable { get; set; }

		[FieldOffset(641, 757)]
		public bool DebugDrawOccluder { get; set; }

		[FieldOffset(642, 758)]
		public bool Element1Enable { get; set; }

		[FieldOffset(643, 759)]
		public bool Element1RotationAlignedToRay { get; set; }

		[FieldOffset(644, 760)]
		public bool Element2Enable { get; set; }

		[FieldOffset(645, 761)]
		public bool Element2RotationAlignedToRay { get; set; }

		[FieldOffset(646, 762)]
		public bool Element3Enable { get; set; }

		[FieldOffset(647, 763)]
		public bool Element3RotationAlignedToRay { get; set; }

		[FieldOffset(648, 764)]
		public bool Element4Enable { get; set; }

		[FieldOffset(649, 765)]
		public bool Element4RotationAlignedToRay { get; set; }

		[FieldOffset(650, 766)]
		public bool Element5Enable { get; set; }

		[FieldOffset(651, 767)]
		public bool Element5RotationAlignedToRay { get; set; }
	}
}

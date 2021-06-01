using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class MeshCopyOptions : LinkObject
	{
		[FieldOffset(0, 0)]
		public Vec4 SpawnRateOverTime { get; set; }

		[FieldOffset(16, 16)]
		public Vec4 LifetimeOverTime { get; set; }

		[FieldOffset(32, 32)]
		public Vec4 CopyDelayOverTime { get; set; }

		[FieldOffset(48, 48)]
		public Vec3 Offset { get; set; }

		[FieldOffset(64, 64)]
		public Vec4 OffsetOverTime { get; set; }

		[FieldOffset(80, 80)]
		public Vec4 YawOverTime { get; set; }

		[FieldOffset(96, 96)]
		public int MaxCopies { get; set; }

		[FieldOffset(100, 100)]
		public float SpawnRate { get; set; }

		[FieldOffset(104, 104)]
		public float Lifetime { get; set; }

		[FieldOffset(108, 108)]
		public MeshCopyIndexSelection LifetimeIndex { get; set; }

		[FieldOffset(112, 112)]
		public float CopyDelay { get; set; }

		[FieldOffset(116, 116)]
		public MeshCopyIndexSelection CopyDelayIndex { get; set; }

		[FieldOffset(120, 120)]
		public MeshCopyIndexSelection OffsetIndex { get; set; }

		[FieldOffset(124, 124)]
		public float YawDegrees { get; set; }

		[FieldOffset(128, 128)]
		public MeshCopyIndexSelection YawIndex { get; set; }

		[FieldOffset(132, 136)]
		public string VariationName { get; set; }

		[FieldOffset(136, 144)]
		public int ShaderTechnique { get; set; }

		[FieldOffset(140, 152)]
		public List<MeshCopyShaderParam> ShaderParameters { get; set; }

		[FieldOffset(144, 160)]
		public List<MeshCopyAnimation> Animations { get; set; }

		[FieldOffset(148, 168)]
		public MeshCopyAnimationSelection AnimationUsage { get; set; }

		[FieldOffset(152, 176)]
		public ExternalObject<EntityProvider> MeshSource { get; set; }

		[FieldOffset(156, 184)]
		public ExternalObject<TransformProvider> Transform { get; set; }

		[FieldOffset(160, 192)]
		public bool NormalizeTime { get; set; }

		[FieldOffset(161, 193)]
		public bool LocalSpace { get; set; }

		public MeshCopyOptions()
		{
			ShaderParameters = new List<MeshCopyShaderParam>();
			Animations = new List<MeshCopyAnimation>();
		}
	}
}

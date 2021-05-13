using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AntAnimatableComponentMeshData : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntAnimatableComponentMeshRenderType MeshRenderType { get; set; }

		[FieldOffset(4, 4)]
		public AntAnimatableComponentMeshRenderContext MeshRenderContext { get; set; }

		[FieldOffset(8, 8)]
		public ExternalObject<Dummy> Mesh { get; set; }

		[FieldOffset(12, 16)]
		public float CameraRelativeScaleX { get; set; }

		[FieldOffset(16, 20)]
		public float CameraRelativeScaleY { get; set; }

		[FieldOffset(20, 24)]
		public float CameraRelativeScaleZ { get; set; }

		[FieldOffset(24, 28)]
		public float CameraRelativeOffsetX { get; set; }

		[FieldOffset(28, 32)]
		public float CameraRelativeOffsetY { get; set; }

		[FieldOffset(32, 36)]
		public float CameraRelativeOffsetZ { get; set; }
	}
}

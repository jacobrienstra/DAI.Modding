using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_VectorComponent : FloatProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<Vector3Provider_Difference> Vector { get; set; }

		[FieldOffset(12, 40)]
		public ComponentAxis Axis { get; set; }
	}
}

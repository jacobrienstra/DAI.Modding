namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TransformLookAtEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform InputTransform { get; set; }

		[FieldOffset(80, 160)]
		public Vec3 Target { get; set; }

		[FieldOffset(96, 176)]
		public Vec3 UpAxis { get; set; }

		[FieldOffset(112, 192)]
		public bool AutoUpdateOutput { get; set; }
	}
}

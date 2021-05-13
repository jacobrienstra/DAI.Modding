namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PhysicsPartInfo
	{
		[FieldOffset(0, 0)]
		public uint PartComponentIndex { get; set; }

		[FieldOffset(4, 4)]
		public uint HealthStateIndex { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialDecl : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint Packed { get; set; }
	}
}

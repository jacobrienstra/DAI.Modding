namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAutoTargetingComponentBinding : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntRef LookAtTargetPosition { get; set; }
	}
}

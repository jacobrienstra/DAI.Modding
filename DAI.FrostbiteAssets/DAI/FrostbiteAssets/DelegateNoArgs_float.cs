namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateNoArgs_float : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<Script> TargetScript { get; set; }
	}
}

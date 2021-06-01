namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LuaFloatProvider : CSMFloatProvider
	{
		[FieldOffset(8, 32)]
		public Delegate_float Delegate { get; set; }
	}
}

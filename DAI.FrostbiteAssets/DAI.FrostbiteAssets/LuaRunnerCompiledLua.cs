namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class LuaRunnerCompiledLua : Asset
	{
		[FieldOffset(16, 72)]
		public long CompiledLuaResource { get; set; }
	}
}

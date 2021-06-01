using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Script : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<EngineImplementedScript> EngineScript { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<DelegateArgument>> ScriptArguments { get; set; }

		[FieldOffset(20, 88)]
		public ExternalObject<LuaRunnerCompiledLua> CompiledLua { get; set; }

		public Script()
		{
			ScriptArguments = new List<ExternalObject<DelegateArgument>>();
		}
	}
}

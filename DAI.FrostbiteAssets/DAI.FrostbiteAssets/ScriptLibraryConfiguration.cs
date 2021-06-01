using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScriptLibraryConfiguration : SystemSettings
	{
		[FieldOffset(16, 40)]
		public List<ExternalObject<GameSettings>> Libraries { get; set; }

		public ScriptLibraryConfiguration()
		{
			Libraries = new List<ExternalObject<GameSettings>>();
		}
	}
}

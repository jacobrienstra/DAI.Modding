using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpawnTemplate : Asset
	{
		[FieldOffset(12, 72)]
		public List<SpawnTemplateComponent> Components { get; set; }

		public SpawnTemplate()
		{
			Components = new List<SpawnTemplateComponent>();
		}
	}
}

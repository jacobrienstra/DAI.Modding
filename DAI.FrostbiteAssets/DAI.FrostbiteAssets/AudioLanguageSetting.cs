using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioLanguageSetting : DataContainer
	{
		[FieldOffset(8, 24)]
		public string Name { get; set; }

		[FieldOffset(12, 32)]
		public uint NameHash { get; set; }

		[FieldOffset(16, 40)]
		public string DisplayName { get; set; }

		[FieldOffset(20, 48)]
		public List<AudioLanguageMapping> Mappings { get; set; }

		[FieldOffset(24, 56)]
		public bool IsDefault { get; set; }

		public AudioLanguageSetting()
		{
			Mappings = new List<AudioLanguageMapping>();
		}
	}
}

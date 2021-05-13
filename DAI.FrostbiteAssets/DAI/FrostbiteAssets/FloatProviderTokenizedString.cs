using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProviderTokenizedString : LinkObject
	{
		[FieldOffset(0, 0)]
		public LocalizedStringReference StringReference { get; set; }

		[FieldOffset(4, 24)]
		public List<ExternalObject<FloatProvider>> Parameters { get; set; }

		[FieldOffset(8, 32)]
		public bool AppendToMain { get; set; }

		public FloatProviderTokenizedString()
		{
			Parameters = new List<ExternalObject<FloatProvider>>();
		}
	}
}

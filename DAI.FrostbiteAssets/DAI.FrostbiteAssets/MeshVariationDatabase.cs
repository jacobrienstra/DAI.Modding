using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MeshVariationDatabase : Asset
	{
		[FieldOffset(12, 72)]
		public List<MeshVariationDatabaseEntry> Entries { get; set; }

		[FieldOffset(16, 80)]
		public List<MeshVariationDatabaseRedirectEntry> RedirectEntries { get; set; }

		public MeshVariationDatabase()
		{
			Entries = new List<MeshVariationDatabaseEntry>();
			RedirectEntries = new List<MeshVariationDatabaseRedirectEntry>();
		}
	}
}

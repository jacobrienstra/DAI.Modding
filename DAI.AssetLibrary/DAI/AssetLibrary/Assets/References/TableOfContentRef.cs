using System.Collections.Generic;

namespace DAI.AssetLibrary.Assets.References
{
	public class TableOfContentRef : EntryRef
	{
		public string Name { get; set; }

		public bool Cas { get; set; }

		public bool AlwaysEmitSuperBundle { get; set; }

		public string Tag { get; set; }

		public long? TotalSize { get; set; }

		public IList<ChunkRef> Chunks { get; set; }

		public IList<BundleRef> Bundles { get; set; }

		public IList<SubBundleRef> SubBundles { get; private set; }

		internal TableOfContentRef()
		{
			Name = string.Empty;
			Tag = string.Empty;
			Chunks = new List<ChunkRef>();
			Bundles = new List<BundleRef>();
			SubBundles = new List<SubBundleRef>();
		}
	}
}

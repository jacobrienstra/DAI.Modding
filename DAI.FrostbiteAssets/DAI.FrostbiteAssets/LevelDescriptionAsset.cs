using System;
using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LevelDescriptionAsset : Asset
	{
		[FieldOffset(12, 72)]
		public string LevelName { get; set; }

		[FieldOffset(16, 80)]
		public List<LevelDescriptionInclusionCategory> Categories { get; set; }

		[FieldOffset(20, 88)]
		public LevelDescription Description { get; set; }

		[FieldOffset(36, 120)]
		public List<LevelBundleLoad> Bundles { get; set; }

		[FieldOffset(40, 128)]
		public List<LevelStartPoint> StartPoints { get; set; }

		[FieldOffset(44, 136)]
		public List<string> SuperBundles { get; set; }

		[FieldOffset(48, 144)]
		public Guid LevelGuid { get; set; }

		public LevelDescriptionAsset()
		{
			Categories = new List<LevelDescriptionInclusionCategory>();
			Bundles = new List<LevelBundleLoad>();
			StartPoints = new List<LevelStartPoint>();
			SuperBundles = new List<string>();
		}
	}
}

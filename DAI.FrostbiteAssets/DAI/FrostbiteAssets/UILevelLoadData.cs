using System;
using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UILevelLoadData : DataContainer
	{
		[FieldOffset(8, 24)]
		public Guid LoadingMovieGuid { get; set; }

		[FieldOffset(24, 40)]
		public string ScreenDataPath { get; set; }

		[FieldOffset(28, 48)]
		public string WidgetDataPath { get; set; }

		[FieldOffset(32, 56)]
		public List<string> ImagePaths { get; set; }

		[FieldOffset(36, 64)]
		public List<GameTipEntry> GameTipEntries { get; set; }

		[FieldOffset(40, 72)]
		public List<int> CodexTipCategoryTitleStringIds { get; set; }

		[FieldOffset(44, 80)]
		public bool HasLoadingMovie { get; set; }

		public UILevelLoadData()
		{
			ImagePaths = new List<string>();
			GameTipEntries = new List<GameTipEntry>();
			CodexTipCategoryTitleStringIds = new List<int>();
		}
	}
}

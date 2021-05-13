namespace DAI.AssetLibrary.Utilities
{
	public class LibraryEventManager
	{
		public delegate void LibraryEventManagerEventHandler(LibraryEventManagerArgs e);

		public event LibraryEventManagerEventHandler BeginTocParsing;

		public event LibraryEventManagerEventHandler BeginGameFolderParsing;

		internal void OnBeginTocParsing(string tocName)
		{
			if (this.BeginTocParsing != null)
			{
				this.BeginTocParsing(new LibraryEventManagerArgs($"Parsing {tocName}"));
			}
		}

		internal void OnBeginGameFolderParsing(string folderName, int nbTocs)
		{
			if (this.BeginGameFolderParsing != null)
			{
				this.BeginGameFolderParsing(new LibraryEventManagerArgs($"Parsing folder {folderName}", nbTocs));
			}
		}
	}
}

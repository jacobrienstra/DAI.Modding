namespace DAI.ModMaker.DAIMod
{
	public class ModDetail
	{
		public string Name;

		public string Version;

		public string Author;

		public string Description;

		public ModDetail()
		{
		}

		public ModDetail(string InName, string InVersion, string InAuthor, string InDescription)
		{
			Name = InName;
			Version = InVersion;
			Author = InAuthor;
			Description = InDescription;
		}
	}
}

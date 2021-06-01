using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class JournalSystem : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<CodexEntry>> CodexEntries { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<CodexEntry>> JournalEntries { get; set; }

		[FieldOffset(20, 88)]
		public List<ExternalObject<CodexEntry>> MissionEntries { get; set; }

		[FieldOffset(24, 96)]
		public List<JournalTextData> JournalTextData { get; set; }

		[FieldOffset(28, 104)]
		public List<JournalTaskData> JournalTaskData { get; set; }

		[FieldOffset(32, 112)]
		public List<ProgressiveTaskData> ProgressiveTaskData { get; set; }

		[FieldOffset(36, 120)]
		public List<ExternalObject<CodexEntry>> Categories { get; set; }

		[FieldOffset(40, 128)]
		public List<string> LoadScreenMarkupBlacklist { get; set; }

		public JournalSystem()
		{
			CodexEntries = new List<ExternalObject<CodexEntry>>();
			JournalEntries = new List<ExternalObject<CodexEntry>>();
			MissionEntries = new List<ExternalObject<CodexEntry>>();
			JournalTextData = new List<JournalTextData>();
			JournalTaskData = new List<JournalTaskData>();
			ProgressiveTaskData = new List<ProgressiveTaskData>();
			Categories = new List<ExternalObject<CodexEntry>>();
			LoadScreenMarkupBlacklist = new List<string>();
		}
	}
}

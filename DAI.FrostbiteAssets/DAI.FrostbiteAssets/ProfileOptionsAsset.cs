using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProfileOptionsAsset : Asset
	{
		[FieldOffset(12, 72)]
		public string FileName { get; set; }

		[FieldOffset(16, 80)]
		public string ContentName { get; set; }

		[FieldOffset(20, 88)]
		public uint FileSize { get; set; }

		[FieldOffset(24, 96)]
		public List<ExternalObject<ProfileOptionDataFloat>> Options { get; set; }

		[FieldOffset(28, 104)]
		public List<ExternalObject<ProfileOptionDataFloat>> OptionsPs3 { get; set; }

		[FieldOffset(32, 112)]
		public List<ExternalObject<ProfileOptionDataFloat>> OptionsXenon { get; set; }

		[FieldOffset(36, 120)]
		public List<ExternalObject<ProfileOptionDataFloat>> OptionsGen4a { get; set; }

		[FieldOffset(40, 128)]
		public List<ExternalObject<ProfileOptionDataFloat>> OptionsGen4b { get; set; }

		[FieldOffset(44, 136)]
		public List<ExternalObject<ProfileOptionDataFloat>> OptionsWin { get; set; }

		[FieldOffset(48, 144)]
		public bool AutoSaveOnQuit { get; set; }

		public ProfileOptionsAsset()
		{
			Options = new List<ExternalObject<ProfileOptionDataFloat>>();
			OptionsPs3 = new List<ExternalObject<ProfileOptionDataFloat>>();
			OptionsXenon = new List<ExternalObject<ProfileOptionDataFloat>>();
			OptionsGen4a = new List<ExternalObject<ProfileOptionDataFloat>>();
			OptionsGen4b = new List<ExternalObject<ProfileOptionDataFloat>>();
			OptionsWin = new List<ExternalObject<ProfileOptionDataFloat>>();
		}
	}
}

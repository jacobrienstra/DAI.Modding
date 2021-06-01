using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIGraphAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<UINodeData>> Nodes { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<Dummy> GlobalNode { get; set; }

		[FieldOffset(20, 88)]
		public List<ExternalObject<UINodeData>> Connections { get; set; }

		[FieldOffset(24, 96)]
		public ExternalObject<UIAudioEventAsset> AudioEventMappings { get; set; }

		[FieldOffset(28, 104)]
		public string BundleAssetName { get; set; }

		[FieldOffset(32, 112)]
		public List<ExternalObject<UINodeData>> EventList { get; set; }

		[FieldOffset(36, 120)]
		public bool ProtectScreens { get; set; }

		[FieldOffset(37, 121)]
		public bool Modal { get; set; }

		[FieldOffset(38, 122)]
		public bool IsWin32UIGraphAsset { get; set; }

		[FieldOffset(39, 123)]
		public bool IsXenonUIGraphAsset { get; set; }

		[FieldOffset(40, 124)]
		public bool IsPs3UIGraphAsset { get; set; }

		[FieldOffset(41, 125)]
		public bool IsGen4aUIGraphAsset { get; set; }

		[FieldOffset(42, 126)]
		public bool IsGen4bUIGraphAsset { get; set; }

		[FieldOffset(43, 127)]
		public bool IsAndroidUIGraphAsset { get; set; }

		[FieldOffset(44, 128)]
		public bool IsiOSUIGraphAsset { get; set; }

		[FieldOffset(45, 129)]
		public bool IsOSXUIGraphAsset { get; set; }

		public UIGraphAsset()
		{
			Nodes = new List<ExternalObject<UINodeData>>();
			Connections = new List<ExternalObject<UINodeData>>();
			EventList = new List<ExternalObject<UINodeData>>();
		}
	}
}

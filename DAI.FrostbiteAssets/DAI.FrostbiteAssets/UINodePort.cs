using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UINodePort : DataContainer
	{
		[FieldOffset(8, 24)]
		public string Name { get; set; }

		[FieldOffset(12, 32)]
		public string InstanceName { get; set; }

		[FieldOffset(16, 40)]
		public UIWidgetEventID Query { get; set; }

		[FieldOffset(20, 44)]
		public bool AllowManualRemove { get; set; }

		[FieldOffset(21, 45)]
		public bool IsReferencePort { get; set; }
	}
}

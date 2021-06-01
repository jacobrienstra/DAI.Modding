namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeadMorphPreset : LinkObject
	{
		[FieldOffset(0, 0)]
		public LocalizedStringReference PresetTitle { get; set; }

		[FieldOffset(4, 24)]
		public ExternalObject<MorphStatic> DefaultShaderSettings { get; set; }
	}
}

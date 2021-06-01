namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EffectSystemComponent : SubWorldDataComponent
	{
		[FieldOffset(8, 24)]
		public ExternalObject<EffectParameterList> ParameterList { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<EmitterTagList> TagList { get; set; }
	}
}

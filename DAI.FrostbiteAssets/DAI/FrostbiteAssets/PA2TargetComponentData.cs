namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PA2TargetComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<PA2TargetProperties> TargetProperties { get; set; }
	}
}

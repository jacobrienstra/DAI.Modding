namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ForceComponentData : ComponentData
	{
		[FieldOffset(96, 176)]
		public float WindScale { get; set; }
	}
}

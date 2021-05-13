namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class VisualEnvironmentEntityData : GameComponentEntityData
	{
		[FieldOffset(112, 208)]
		public float Visibility { get; set; }

		[FieldOffset(116, 212)]
		public int Priority { get; set; }
	}
}

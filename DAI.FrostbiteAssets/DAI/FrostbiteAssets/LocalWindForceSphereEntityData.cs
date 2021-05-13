namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LocalWindForceSphereEntityData : LocalWindForceEntityBaseData
	{
		[FieldOffset(112, 208)]
		public float Radius { get; set; }
	}
}

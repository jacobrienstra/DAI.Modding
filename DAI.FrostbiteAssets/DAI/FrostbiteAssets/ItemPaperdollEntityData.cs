namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ItemPaperdollEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform TiltedTransform { get; set; }

		[FieldOffset(80, 160)]
		public LinearTransform NonTiltedTransform { get; set; }
	}
}

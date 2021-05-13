namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InputActionData : DataContainer
	{
		[FieldOffset(8, 24)]
		public bool IsAnalog { get; set; }

		[FieldOffset(9, 25)]
		public bool NegateValue { get; set; }
	}
}

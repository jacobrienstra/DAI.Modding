namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PersistentFloatVariableEntityData : PersistentVariableEntityBaseData
	{
		[FieldOffset(20, 112)]
		public float InputValue { get; set; }
	}
}

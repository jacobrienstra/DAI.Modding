namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PersistentBooleanVariableEntityData : PersistentVariableEntityBaseData
	{
		[FieldOffset(20, 112)]
		public bool InputValue { get; set; }
	}
}

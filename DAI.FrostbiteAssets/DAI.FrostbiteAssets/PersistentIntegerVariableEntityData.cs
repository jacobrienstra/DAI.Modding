namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PersistentIntegerVariableEntityData : PersistentVariableEntityBaseData
	{
		[FieldOffset(20, 112)]
		public int InputValue { get; set; }

		[FieldOffset(24, 116)]
		public int IncDecValue { get; set; }
	}
}

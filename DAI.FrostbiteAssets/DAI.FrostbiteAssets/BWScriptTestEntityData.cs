namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWScriptTestEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Delegate_bool BoolDelegate { get; set; }

		[FieldOffset(28, 120)]
		public Delegate_float FloatDelegate { get; set; }

		[FieldOffset(40, 144)]
		public Delegate_int IntDelegate { get; set; }
	}
}

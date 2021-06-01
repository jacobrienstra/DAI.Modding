namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_DoSetTacticCommand : BTTaskFunc
	{
		[FieldOffset(12, 32)]
		public ExternalObject<TacticsCommandData> TacticCommand { get; set; }
	}
}

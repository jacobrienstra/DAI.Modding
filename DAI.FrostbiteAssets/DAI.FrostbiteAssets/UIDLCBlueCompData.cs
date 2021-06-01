namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIDLCBlueCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public ExternalObject<BWActivatedAbility> AnchorDischargeAbility { get; set; }

		[FieldOffset(36, 144)]
		public PlotFlagReference AnchorDischargeEnabledFlag { get; set; }

		[FieldOffset(52, 184)]
		public int DLCPackage { get; set; }
	}
}

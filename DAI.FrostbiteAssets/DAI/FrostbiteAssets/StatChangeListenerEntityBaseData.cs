namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StatChangeListenerEntityBaseData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<BWStat> Stat { get; set; }

		[FieldOffset(20, 104)]
		public ExternalObject<Dummy> Entity { get; set; }
	}
}

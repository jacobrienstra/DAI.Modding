using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CSMContextProviderData : ContextProviderData
	{
		[FieldOffset(16, 96)]
		public LinearTransform TargetTransform { get; set; }

		[FieldOffset(80, 160)]
		public Realm Realm { get; set; }

		[FieldOffset(84, 168)]
		public ExternalObject<Dummy> InputList { get; set; }

		[FieldOffset(88, 176)]
		public ExternalObject<Dummy> PartnerInputList { get; set; }

		[FieldOffset(92, 184)]
		public ExternalObject<Dummy> CasterInputList { get; set; }
	}
}

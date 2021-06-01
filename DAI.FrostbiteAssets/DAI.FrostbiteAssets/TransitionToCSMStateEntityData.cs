using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TransitionToCSMStateEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public ExternalObject<CSMStateReference> StateReference { get; set; }

		[FieldOffset(24, 112)]
		public bool CopyContextFromPreviousState { get; set; }
	}
}

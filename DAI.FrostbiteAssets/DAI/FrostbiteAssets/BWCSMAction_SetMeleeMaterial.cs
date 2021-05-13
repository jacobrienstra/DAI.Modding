namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetMeleeMaterial : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public string CollisionId { get; set; }

		[FieldOffset(32, 80)]
		public MaterialDecl ReceiverMaterialPair { get; set; }

		[FieldOffset(36, 96)]
		public MaterialDecl BarrierMaterialPair { get; set; }

		[FieldOffset(40, 112)]
		public MaterialDecl ArmoredMaterialPair { get; set; }

		[FieldOffset(44, 128)]
		public int TargetIndex { get; set; }

		[FieldOffset(48, 132)]
		public bool ResetAtEnd { get; set; }
	}
}

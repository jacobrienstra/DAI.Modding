namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetBuffMaterial : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public string CollisionId { get; set; }

		[FieldOffset(32, 80)]
		public MaterialDecl AttackingMaterialPair { get; set; }

		[FieldOffset(36, 96)]
		public MaterialDecl HealthMaterialPair { get; set; }

		[FieldOffset(40, 112)]
		public MaterialDecl BarrierMaterialPair { get; set; }

		[FieldOffset(44, 128)]
		public MaterialDecl ArmoredMaterialPair { get; set; }

		[FieldOffset(48, 144)]
		public int TargetIndex { get; set; }

		[FieldOffset(52, 148)]
		public bool ResetAtEnd { get; set; }

		[FieldOffset(53, 149)]
		public bool CompleteOverride { get; set; }
	}
}

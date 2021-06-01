namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCombatantComponentData : BWSkeletalTargetComponentData
	{
		[FieldOffset(112, 208)]
		public float PhysicalRadiusCombat { get; set; }

		[FieldOffset(116, 212)]
		public BWTicketTakerInfo TargetTickets { get; set; }

		[FieldOffset(124, 220)]
		public BWTicketTakerInfo AttackTickets { get; set; }

		[FieldOffset(132, 228)]
		public BWTicketTakerInfo InteractionTickets { get; set; }

		[FieldOffset(140, 236)]
		public BWTicketTakerInfo SpecialAttackTickets { get; set; }

		[FieldOffset(148, 244)]
		public BWTicketTakerInfo CustomTickets4 { get; set; }

		[FieldOffset(156, 252)]
		public BWTicketTakerInfo CustomTickets5 { get; set; }

		[FieldOffset(164, 260)]
		public BWTicketTakerInfo CustomTickets6 { get; set; }

		[FieldOffset(172, 268)]
		public int NumAttackArcs { get; set; }

		[FieldOffset(176, 272)]
		public float StickToTargetAttackRadius { get; set; }

		[FieldOffset(180, 276)]
		public int AttackTargetOverride { get; set; }

		[FieldOffset(184, 280)]
		public bool ArmourGate { get; set; }

		[FieldOffset(185, 281)]
		public bool BarrierGate { get; set; }

		[FieldOffset(186, 282)]
		public bool HealthGate { get; set; }

		[FieldOffset(187, 283)]
		public bool NeutralCombatant { get; set; }
	}
}

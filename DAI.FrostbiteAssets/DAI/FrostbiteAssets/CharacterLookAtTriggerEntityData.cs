namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CharacterLookAtTriggerEntityData : TriggerEventEntityData
	{
		[FieldOffset(96, 192)]
		public float FOV { get; set; }

		[FieldOffset(100, 196)]
		public float MinDistanceToObject { get; set; }

		[FieldOffset(104, 200)]
		public float MaxDistanceToObject { get; set; }

		[FieldOffset(108, 204)]
		public bool StartTriggerLookingAt { get; set; }

		[FieldOffset(109, 205)]
		public bool CheckOcclusion { get; set; }

		[FieldOffset(110, 206)]
		public bool UseEntityDirection { get; set; }
	}
}

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_Rumble : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public float Low { get; set; }

		[FieldOffset(32, 76)]
		public float High { get; set; }

		[FieldOffset(36, 80)]
		public bool ControlledCharacter { get; set; }

		[FieldOffset(37, 81)]
		public bool ControlledCharacterInstigator { get; set; }

		[FieldOffset(38, 82)]
		public bool Always { get; set; }
	}
}

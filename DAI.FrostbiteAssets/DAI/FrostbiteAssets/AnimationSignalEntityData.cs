namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AnimationSignalEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public AntRef Signal { get; set; }

		[FieldOffset(36, 144)]
		public AntRef IntGameState { get; set; }

		[FieldOffset(56, 192)]
		public AntRef FloatGameState { get; set; }

		[FieldOffset(76, 240)]
		public int ValueInt { get; set; }

		[FieldOffset(80, 244)]
		public float ValueFloat { get; set; }

		[FieldOffset(84, 248)]
		public bool Reset { get; set; }

		[FieldOffset(85, 249)]
		public bool Continuous { get; set; }
	}
}

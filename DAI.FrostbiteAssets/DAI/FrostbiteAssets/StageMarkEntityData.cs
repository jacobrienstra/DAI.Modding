namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class StageMarkEntityData : StageObjectEntityData
	{
		[FieldOffset(96, 192)]
		public ExternalObject<StageCameraEntityData> DefaultCamera { get; set; }

		[FieldOffset(100, 200)]
		public ExternalObject<StageCameraEntityData> CloseUpCamera { get; set; }

		[FieldOffset(104, 208)]
		public ExternalObject<StageCameraEntityData> WideCamera { get; set; }

		[FieldOffset(108, 216)]
		public ExternalObject<CharacterBlueprint> Blueprint { get; set; }

		[FieldOffset(112, 224)]
		public ExternalObject<PoseDefinition> Pose { get; set; }
	}
}

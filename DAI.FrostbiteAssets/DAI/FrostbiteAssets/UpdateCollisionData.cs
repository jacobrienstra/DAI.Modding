using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpdateCollisionData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float Restitution { get; set; }

		[FieldOffset(20, 68)]
		public float ReflectionBias { get; set; }

		[FieldOffset(24, 72)]
		public float RestSpeedThreshold { get; set; }

		[FieldOffset(28, 76)]
		public float Randomness { get; set; }

		[FieldOffset(32, 80)]
		public EmitterCollisionMethod Method { get; set; }

		[FieldOffset(36, 84)]
		public EmitterCollisionPriority Priority { get; set; }
	}
}

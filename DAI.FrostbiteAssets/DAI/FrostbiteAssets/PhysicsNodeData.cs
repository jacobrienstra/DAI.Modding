using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PhysicsNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Distance { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Velocity { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort RelativeVelocity { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort Azimuth { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort ElevationAngle { get; set; }

		[FieldOffset(48, 208)]
		public AudioGraphNodePort RelativeOrientation { get; set; }

		[FieldOffset(56, 240)]
		public List<ExternalObject<Dummy>> Entries { get; set; }

		public PhysicsNodeData()
		{
			Entries = new List<ExternalObject<Dummy>>();
		}
	}
}

using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class HealthStateData : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<ExternalObject<DataContainer>> Objects { get; set; }

		[FieldOffset(12, 32)]
		public List<ExternalObject<Dummy>> LoosePartPhysics { get; set; }

		[FieldOffset(16, 40)]
		public ExternalObject<Dummy> SpawnedBangerBlueprint { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<Dummy> SpawnedBangerImpulseParams { get; set; }

		[FieldOffset(24, 56)]
		public float Health { get; set; }

		[FieldOffset(28, 60)]
		public uint PartIndex { get; set; }

		[FieldOffset(32, 64)]
		public bool CopyDamageToBanger { get; set; }

		[FieldOffset(33, 65)]
		public bool PhysicsEnabled { get; set; }

		[FieldOffset(34, 66)]
		public bool Indestructable { get; set; }

		[FieldOffset(35, 67)]
		public bool CanSupportOtherParts { get; set; }

		public HealthStateData()
		{
			Objects = new List<ExternalObject<DataContainer>>();
			LoosePartPhysics = new List<ExternalObject<Dummy>>();
		}
	}
}

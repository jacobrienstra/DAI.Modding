using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ParticleSoundEffectEntityData : EffectEntityData
	{
		[FieldOffset(128, 240)]
		public Guid EmitterGuid { get; set; }

		[FieldOffset(144, 256)]
		public ExternalObject<SoundPatchConfigurationAsset> SpawnSound { get; set; }

		[FieldOffset(148, 264)]
		public ExternalObject<SoundPatchConfigurationAsset> DeathSound { get; set; }

		[FieldOffset(152, 272)]
		public uint MaxParticlesWithSound { get; set; }

		[FieldOffset(156, 276)]
		public bool SoundWillFollowParticle { get; set; }
	}
}

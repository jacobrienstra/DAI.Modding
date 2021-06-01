using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EmitterEntityData : EffectEntityData
	{
		[FieldOffset(128, 240)]
		public ExternalObject<ScalableEmitterDocument> Emitter { get; set; }

		[FieldOffset(132, 248)]
		public QualityScalableFloat SpawnProbability { get; set; }

		[FieldOffset(148, 264)]
		public int AttachToId { get; set; }

		[FieldOffset(152, 272)]
		public List<ExternalObject<Dummy>> EmitterTags { get; set; }

		[FieldOffset(156, 280)]
		public byte DrawOrderSlot { get; set; }

		[FieldOffset(157, 281)]
		public bool LocalPlayerOnly { get; set; }

		public EmitterEntityData()
		{
			EmitterTags = new List<ExternalObject<Dummy>>();
		}
	}
}

using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WorldPartData : PrefabBlueprint
	{
		[FieldOffset(40, 192)]
		public Guid HackToSolveRealTimeTweakingIssue { get; set; }

		[FieldOffset(56, 208)]
		public bool Enabled { get; set; }

		[FieldOffset(57, 209)]
		public bool UseDeferredEntityCreation { get; set; }
	}
}

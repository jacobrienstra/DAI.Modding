using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ClothStatesSetup : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<uint> States { get; set; }

		[FieldOffset(4, 8)]
		public List<ClothStateSetupTransitionLookup> StatesTransitionLookups { get; set; }

		[FieldOffset(8, 16)]
		public List<ClothStateSetupTransition> StatesTransitions { get; set; }

		[FieldOffset(12, 24)]
		public uint EmptyState { get; set; }

		[FieldOffset(16, 32)]
		public List<uint> FullSkinStates { get; set; }

		public ClothStatesSetup()
		{
			States = new List<uint>();
			StatesTransitionLookups = new List<ClothStateSetupTransitionLookup>();
			StatesTransitions = new List<ClothStateSetupTransition>();
			FullSkinStates = new List<uint>();
		}
	}
}

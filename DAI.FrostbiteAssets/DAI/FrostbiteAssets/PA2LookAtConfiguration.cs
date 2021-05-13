using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PA2LookAtConfiguration : SystemSettings
	{
		[FieldOffset(16, 40)]
		public List<ExternalObject<SystemSettings>> OnGameStates { get; set; }

		[FieldOffset(20, 48)]
		public List<ExternalObject<SystemSettings>> OffGameStates { get; set; }

		[FieldOffset(24, 56)]
		public AntRef ControllerGameState { get; set; }

		[FieldOffset(44, 104)]
		public int DefaultOnController { get; set; }

		[FieldOffset(48, 108)]
		public int OffController { get; set; }

		[FieldOffset(52, 112)]
		public AntRef TargetGameState { get; set; }

		[FieldOffset(72, 160)]
		public AntRef SnapToTargetGameState { get; set; }

		public PA2LookAtConfiguration()
		{
			OnGameStates = new List<ExternalObject<SystemSettings>>();
			OffGameStates = new List<ExternalObject<SystemSettings>>();
		}
	}
}

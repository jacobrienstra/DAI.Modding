using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ControllableEntityData : GamePhysicsEntityData
	{
		[FieldOffset(128, 240)]
		public TeamId DefaultTeam { get; set; }

		[FieldOffset(132, 244)]
		public float LowHealthThreshold { get; set; }

		[FieldOffset(136, 248)]
		public MaterialDecl MaterialPair { get; set; }

		[FieldOffset(140, 264)]
		public bool UsePrediction { get; set; }

		[FieldOffset(141, 265)]
		public bool ResetTeamOnLastPlayerExits { get; set; }

		[FieldOffset(142, 266)]
		public bool Immortal { get; set; }

		[FieldOffset(143, 267)]
		public bool FakeImmortal { get; set; }

		[FieldOffset(144, 268)]
		public bool ForceForegroundRendering { get; set; }
	}
}

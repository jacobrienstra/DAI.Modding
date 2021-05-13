using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameAnimationSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public List<Dummy> AntOnClientOnlyGamemodes { get; set; }

		[FieldOffset(20, 48)]
		public float TemporalLoddingFirstDeltaTime { get; set; }

		[FieldOffset(24, 52)]
		public float TemporalLoddingSecondDeltaTime { get; set; }

		[FieldOffset(28, 56)]
		public float TemporalLoddingThirdDeltaTime { get; set; }

		[FieldOffset(32, 60)]
		public float TemporalLoddingFourthDeltaTime { get; set; }

		[FieldOffset(36, 64)]
		public float TemporalLoddingFifthDeltaTime { get; set; }

		[FieldOffset(40, 68)]
		public float TemporalLoddingSixthDeltaTime { get; set; }

		[FieldOffset(44, 72)]
		public float TemporalLoddingFirstDistance { get; set; }

		[FieldOffset(48, 76)]
		public float TemporalLoddingSecondDistance { get; set; }

		[FieldOffset(52, 80)]
		public float TemporalLoddingThirdDistance { get; set; }

		[FieldOffset(56, 84)]
		public float TemporalLoddingFourthDistance { get; set; }

		[FieldOffset(60, 88)]
		public float TemporalLoddingFifthDistance { get; set; }

		[FieldOffset(64, 92)]
		public float TemporalLoddingSixthDistance { get; set; }

		[FieldOffset(68, 96)]
		public float TemporalLoddingFarDistance { get; set; }

		[FieldOffset(72, 100)]
		public bool UseAnimationDrivenCharacter { get; set; }

		[FieldOffset(73, 101)]
		public bool ServerEnable { get; set; }

		[FieldOffset(74, 102)]
		public bool ClientEnable { get; set; }

		[FieldOffset(75, 103)]
		public bool UseRawGamepadInput { get; set; }

		public GameAnimationSettings()
		{
			AntOnClientOnlyGamemodes = new List<Dummy>();
		}
	}
}

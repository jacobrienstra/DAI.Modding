using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MathEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public MathEntityAssembly Assembly { get; set; }

		[FieldOffset(28, 136)]
		public bool EvaluateOnEvent { get; set; }

		[FieldOffset(29, 137)]
		public bool WaitForAllInputs { get; set; }
	}
}

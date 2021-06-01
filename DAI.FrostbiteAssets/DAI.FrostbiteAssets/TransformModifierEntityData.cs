using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TransformModifierEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform In { get; set; }

		[FieldOffset(80, 160)]
		public Realm Realm { get; set; }

		[FieldOffset(84, 164)]
		public ModifierAxis Left { get; set; }

		[FieldOffset(88, 168)]
		public ModifierAxis Up { get; set; }

		[FieldOffset(92, 172)]
		public ModifierAxis Forward { get; set; }

		[FieldOffset(96, 176)]
		public bool InvertFullTransform { get; set; }

		[FieldOffset(97, 177)]
		public bool InvertLeft { get; set; }

		[FieldOffset(98, 178)]
		public bool InvertUp { get; set; }

		[FieldOffset(99, 179)]
		public bool InvertForward { get; set; }

		[FieldOffset(100, 180)]
		public bool InvertTranslation { get; set; }
	}
}

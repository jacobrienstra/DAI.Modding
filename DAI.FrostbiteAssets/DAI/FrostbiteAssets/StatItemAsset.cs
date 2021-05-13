using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StatItemAsset : BaseItemAsset
	{
		[FieldOffset(80, 248)]
		public ItemQuality Quality { get; set; }

		[FieldOffset(84, 252)]
		public uint Level { get; set; }

		[FieldOffset(88, 256)]
		public ExternalObject<BWModifiableStat> PrimaryStat { get; set; }

		[FieldOffset(92, 264)]
		public List<ExternalObject<DataContainer>> Stats { get; set; }

		[FieldOffset(96, 272)]
		public List<ExternalObject<PlotEvent>> Abilities { get; set; }

		[FieldOffset(100, 280)]
		public ExternalObject<RecipeMaterial> DefaultClothTint { get; set; }

		[FieldOffset(104, 288)]
		public ExternalObject<RecipeMaterial> DefaultSecondClothTint { get; set; }

		[FieldOffset(108, 296)]
		public ExternalObject<RecipeMaterial> DefaultLeatherTint { get; set; }

		[FieldOffset(112, 304)]
		public ExternalObject<RecipeMaterial> DefaultMetalTint { get; set; }

		[FieldOffset(116, 312)]
		public int DamageType { get; set; }

		[FieldOffset(120, 316)]
		public bool ApplyPrimaryStatToCharacterOnEquip { get; set; }

		public StatItemAsset()
		{
			Stats = new List<ExternalObject<DataContainer>>();
			Abilities = new List<ExternalObject<PlotEvent>>();
		}
	}
}

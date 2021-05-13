using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWStat : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public LocalizedStringReference StatName { get; set; }

		[FieldOffset(16, 96)]
		public LocalizedStringReference StatDescription { get; set; }

		[FieldOffset(20, 120)]
		public List<LocalizedStringReference> ModifierNames { get; set; }

		[FieldOffset(24, 128)]
		public float LowerLimit { get; set; }

		[FieldOffset(28, 132)]
		public float UpperLimit { get; set; }

		[FieldOffset(32, 136)]
		public ExternalObject<BWTweakableFloatProvider> BaseValue { get; set; }

		[FieldOffset(36, 144)]
		public ReplicationUrgency ReplicationUrgency { get; set; }

		[FieldOffset(40, 148)]
		public bool ClampBaseValueToLowerLimit { get; set; }

		[FieldOffset(41, 149)]
		public bool ClampBaseValueToUpperLimit { get; set; }

		[FieldOffset(42, 150)]
		public bool DisplayValueAsPercentage { get; set; }

		public BWStat()
		{
			ModifierNames = new List<LocalizedStringReference>();
		}
	}
}

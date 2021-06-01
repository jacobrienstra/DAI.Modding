using System;

namespace DAI.FrostbiteAssets
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class DescriptorAlignmentAttribute : Attribute
	{
		public byte Alignment { get; private set; }

		public DescriptorAlignmentAttribute(int alignment)
		{
			Alignment = (byte)alignment;
		}
	}
}

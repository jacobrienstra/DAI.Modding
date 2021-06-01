using System;

namespace DAI.FrostbiteAssets
{
	[AttributeUsage(AttributeTargets.Property)]
	public class FieldOffsetAttribute : Attribute
	{
		public int Offset { get; private set; }

		public int SecondaryOffset { get; private set; }

		public FieldOffsetAttribute(int offset, int secondaryOffset)
		{
			Offset = offset;
			SecondaryOffset = secondaryOffset;
		}
	}
}

using System;

namespace DAI.FrostbiteAssets
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class ComplexObjectTypeAttribute : Attribute
	{
		public ushort ComplexObjectType { get; private set; }

		public ComplexObjectTypeAttribute(ushort type)
		{
			ComplexObjectType = type;
		}
	}
}

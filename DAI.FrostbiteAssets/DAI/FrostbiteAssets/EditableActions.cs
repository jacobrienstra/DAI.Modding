using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EditableActions : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<ExternalObject<Dummy>> Actions { get; set; }

		public EditableActions()
		{
			Actions = new List<ExternalObject<Dummy>>();
		}
	}
}

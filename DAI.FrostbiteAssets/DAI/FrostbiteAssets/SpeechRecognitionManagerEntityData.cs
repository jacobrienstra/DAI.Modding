using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpeechRecognitionManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<LogicReferenceObjectData>> Grammars { get; set; }

		public SpeechRecognitionManagerEntityData()
		{
			Grammars = new List<ExternalObject<LogicReferenceObjectData>>();
		}
	}
}

using System.IO;

namespace DAI.AssetLibrary.Assets.Bases
{
	public class ArrayRepeater
	{
		public int Offset;

		public int Count;

		public int ComplexDescriptorIndex;

		public ArrayRepeater()
		{
		}

		public ArrayRepeater(int InOffset, int InCount, int InComplexId)
		{
			Offset = InOffset;
			Count = InCount;
			ComplexDescriptorIndex = InComplexId;
		}

		public void Read(BinaryReader Reader, EbxBase EbxFile)
		{
			Offset = Reader.ReadInt32();
			Count = Reader.ReadInt32();
			ComplexDescriptorIndex = Reader.ReadInt32();
		}

		public void Write(BinaryWriter Writer)
		{
			Writer.Write(Offset);
			Writer.Write(Count);
			Writer.Write(ComplexDescriptorIndex);
		}
	}
}

using System.IO;

namespace DAI.AssetLibrary.Assets.Bases
{
	public class InstanceRepeater
	{
		public short ComplexDescriptorIndex;

		public short Count;

		public InstanceRepeater()
		{
		}

		public InstanceRepeater(short InIndex, short InCount)
		{
			ComplexDescriptorIndex = InIndex;
			Count = InCount;
		}

		public void Read(BinaryReader Reader, EbxBase EbxFile)
		{
			ComplexDescriptorIndex = Reader.ReadInt16();
			Count = Reader.ReadInt16();
		}

		public void Write(BinaryWriter Writer)
		{
			Writer.Write(ComplexDescriptorIndex);
			Writer.Write(Count);
		}
	}
}

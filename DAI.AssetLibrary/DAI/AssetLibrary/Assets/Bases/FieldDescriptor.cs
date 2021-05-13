using System.IO;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary.Assets.Bases
{
	public class FieldDescriptor
	{
		public string FieldName;

		public FieldType FieldType;

		public short ComplexReference;

		public int PayloadOffset;

		public int SecondaryOffset;

		public FieldDescriptor()
		{
		}

		public FieldDescriptor(string InFieldName, ushort InFieldType, short InComplexRef, int InPayloadOffset, int InSecondaryOffset)
		{
			FieldName = InFieldName;
			FieldType = (FieldType)InFieldType;
			ComplexReference = InComplexRef;
			PayloadOffset = InPayloadOffset;
			SecondaryOffset = InSecondaryOffset;
		}

		public void Read(BinaryReader Reader, EbxBase EbxFile)
		{
			FieldName = EbxFile.KeywordDict[Reader.ReadInt32()];
			FieldType = (FieldType)Reader.ReadUInt16();
			ComplexReference = Reader.ReadInt16();
			PayloadOffset = Reader.ReadInt32();
			SecondaryOffset = Reader.ReadInt32();
		}

		public override string ToString()
		{
			return FieldName;
		}

		public void Write(BinaryWriter Writer)
		{
			Writer.Write(FieldName.Hash());
			Writer.Write((ushort)FieldType);
			Writer.Write(ComplexReference);
			Writer.Write(PayloadOffset);
			Writer.Write(SecondaryOffset);
		}
	}
}

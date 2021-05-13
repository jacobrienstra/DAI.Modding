using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary.Assets.Bases
{
	public class EbxBase
	{
		private static bool InArray;

		public EbxBaseHeader Header { get; private set; }

		public Guid FileGuid { get; set; }

		public List<ExternalGuid> ExternalGuids { get; private set; }

		public List<Guid> InternalGuids { get; private set; }

		public Dictionary<int, string> KeywordDict { get; private set; }

		public List<string> Strings { get; private set; }

		public List<FieldDescriptor> FieldDescriptors { get; private set; }

		public List<ComplexObjectDescriptor> ComplexDescriptors { get; private set; }

		public List<InstanceRepeater> InstanceRepeaters { get; private set; }

		public List<ArrayRepeater> ArrayRepeaters { get; private set; }

		public Dictionary<Guid, ComplexObject> Instances { get; private set; }

		public ComplexObject RootInstance { get; set; }

		public byte[] Payload { get; set; }

		static EbxBase()
		{
		}

		public EbxBase()
		{
			Header = new EbxBaseHeader();
			ExternalGuids = new List<ExternalGuid>();
			InternalGuids = new List<Guid>();
			KeywordDict = new Dictionary<int, string>();
			Strings = new List<string>();
			FieldDescriptors = new List<FieldDescriptor>();
			ComplexDescriptors = new List<ComplexObjectDescriptor>();
			InstanceRepeaters = new List<InstanceRepeater>();
			ArrayRepeaters = new List<ArrayRepeater>();
			Instances = new Dictionary<Guid, ComplexObject>();
			FileGuid = Guid.Empty;
			Payload = null;
		}

		public static EbxBase FromEbx(EbxRef ebx)
		{
			EbxBase dEbx = new EbxBase();
			byte[] data = PayloadProvider.GetAssetPayload(ebx);
			if (data == null)
			{
				return null;
			}
			using (MemoryStream ms = new MemoryStream(data))
			{
				using (BinaryReader reader = new BinaryReader(ms))
				{
					dEbx.Read(reader);
					return dEbx;
				}
			}
		}

		public static EbxBase DoQuickLookup(EbxRef ebx, ref string name)
		{
			byte[] data = PayloadProvider.GetAssetPayload(ebx);
			if (data == null || data.Length == 0)
			{
				return null;
			}
			EbxBase dEbx = new EbxBase();
			using (MemoryStream ms = new MemoryStream(data))
			{
				using (BinaryReader reader = new BinaryReader(ms))
				{
					dEbx.DoQuickNameLookup(reader, ref name);
					return dEbx;
				}
			}
		}

		private void DoQuickNameLookup(BinaryReader Reader, ref string name)
		{
			if (Reader.ReadUInt32() != 263377358)
			{
				return;
			}
			Header.Read(Reader);
			FileGuid = Reader.ReadGuid();
			while (Reader.BaseStream.Position % 16 != 0L)
			{
				Reader.BaseStream.Seek(1L, SeekOrigin.Current);
			}
			for (int i = 0; i < Header.ExternalGuidCount; i++)
			{
				ExternalGuid dAIExternalGuid = new ExternalGuid(Reader.ReadGuid(), Reader.ReadGuid());
				ExternalGuids.Add(dAIExternalGuid);
			}
			long position = Reader.BaseStream.Position;
			while (Reader.BaseStream.Position - position < Header.NameLength)
			{
				string str = Reader.ReadNullTerminatedString();
				int num = Hasher(str);
				if (!KeywordDict.ContainsKey(num))
				{
					KeywordDict.Add(num, str);
				}
			}
			for (int j = 0; j < Header.FieldCount; j++)
			{
				FieldDescriptor dAIFieldDescriptor = new FieldDescriptor();
				dAIFieldDescriptor.Read(Reader, this);
				FieldDescriptors.Add(dAIFieldDescriptor);
			}
			for (int k = 0; k < Header.ComplexEntryCount; k++)
			{
				ComplexObjectDescriptor dAIComplexDescriptor = new ComplexObjectDescriptor();
				dAIComplexDescriptor.Read(Reader, this);
				ComplexDescriptors.Add(dAIComplexDescriptor);
			}
			InstanceRepeater dAIInstanceRepeater = new InstanceRepeater();
			dAIInstanceRepeater.Read(Reader, this);
			name = ComplexDescriptors[dAIInstanceRepeater.ComplexDescriptorIndex].FieldName;
		}

		private void Read(BinaryReader Reader)
		{
			if (Reader.ReadUInt32() != 263377358)
			{
				return;
			}
			Header.Read(Reader);
			FileGuid = Reader.ReadGuid();
			while (Reader.BaseStream.Position % 16 != 0L)
			{
				Reader.BaseStream.Seek(1L, SeekOrigin.Current);
			}
			for (int i = 0; i < Header.ExternalGuidCount; i++)
			{
				ExternalGuid dAIExternalGuid = new ExternalGuid(Reader.ReadGuid(), Reader.ReadGuid());
				ExternalGuids.Add(dAIExternalGuid);
			}
			long position = Reader.BaseStream.Position;
			while (Reader.BaseStream.Position - position < Header.NameLength)
			{
				string str = Reader.ReadNullTerminatedString();
				int num = Hasher(str);
				if (!KeywordDict.ContainsKey(num))
				{
					KeywordDict.Add(num, str);
				}
			}
			for (int j = 0; j < Header.FieldCount; j++)
			{
				FieldDescriptor dAIFieldDescriptor = new FieldDescriptor();
				dAIFieldDescriptor.Read(Reader, this);
				FieldDescriptors.Add(dAIFieldDescriptor);
			}
			for (int k = 0; k < Header.ComplexEntryCount; k++)
			{
				ComplexObjectDescriptor dAIComplexDescriptor = new ComplexObjectDescriptor();
				dAIComplexDescriptor.Read(Reader, this);
				ComplexDescriptors.Add(dAIComplexDescriptor);
			}
			for (int l = 0; l < Header.InstanceRepeaterCount; l++)
			{
				InstanceRepeater dAIInstanceRepeater = new InstanceRepeater();
				dAIInstanceRepeater.Read(Reader, this);
				InstanceRepeaters.Add(dAIInstanceRepeater);
			}
			while (Reader.BaseStream.Position % 16 != 0L)
			{
				Reader.BaseStream.Seek(1L, SeekOrigin.Current);
			}
			for (int m = 0; m < Header.ArrayRepeaterCount; m++)
			{
				ArrayRepeater dAIArrayRepeater = new ArrayRepeater();
				dAIArrayRepeater.Read(Reader, this);
				ArrayRepeaters.Add(dAIArrayRepeater);
			}
			while (Reader.BaseStream.Position % 16 != 0L)
			{
				Reader.BaseStream.Seek(1L, SeekOrigin.Current);
			}
			while (Reader.BaseStream.Position < Header.StringOffset + Header.StringsLength && Reader.PeekChar() != 0)
			{
				Strings.Add(Reader.ReadNullTerminatedString());
			}
			while (Reader.BaseStream.Position % 16 != 0L)
			{
				Reader.BaseStream.Seek(1L, SeekOrigin.Current);
			}
			int instanceRepeaterIndex = 0;
			int nbCustomGuids = 1;
			foreach (InstanceRepeater instanceRepeater in InstanceRepeaters)
			{
				for (int n = 0; n < instanceRepeater.Count; n++)
				{
					while (Reader.BaseStream.Position % (long)ComplexDescriptors[instanceRepeater.ComplexDescriptorIndex].Alignment != 0L)
					{
						Reader.BaseStream.Seek(1L, SeekOrigin.Current);
					}
					Guid guid = Guid.Empty;
					if (instanceRepeaterIndex >= Header.GuidRepeaterCount)
					{
						guid = GuidExt.GetGuidFromDoubleULong(0uL, (ulong)nbCustomGuids);
						guid = guid.ToBig();
						nbCustomGuids++;
					}
					else
					{
						guid = Reader.ReadGuid();
					}
					InternalGuids.Add(guid);
					Instances.Add(guid, ReadComplex(Reader, instanceRepeater.ComplexDescriptorIndex, true));
				}
				instanceRepeaterIndex++;
			}
			RootInstance = Instances.Values.ElementAt(0);
		}

		private ComplexObject ReadComplex(BinaryReader Reader, int ComplexIndex, bool IsInstance = false)
		{
			int num = ((IsInstance && ComplexDescriptors[ComplexIndex].Alignment == 4) ? 8 : 0);
			ComplexObject dAIComplex = new ComplexObject
			{
				Descriptor = ComplexDescriptors[ComplexIndex],
				Offset = Reader.BaseStream.Position - num
			};
			for (int i = dAIComplex.Descriptor.FieldStartIndex; i < dAIComplex.Descriptor.FieldStartIndex + dAIComplex.Descriptor.FieldCount; i++)
			{
				int baseOffset = ((FieldDescriptors[i].FieldName == "$") ? 8 : 0);
				Reader.BaseStream.Seek(dAIComplex.Offset + FieldDescriptors[i].PayloadOffset - baseOffset, SeekOrigin.Begin);
				dAIComplex.Fields.Add(ReadField(Reader, i));
			}
			Reader.BaseStream.Seek(dAIComplex.Offset + dAIComplex.Descriptor.FieldSize, SeekOrigin.Begin);
			return dAIComplex;
		}

		private int GetCurrentStrOffset()
		{
			int length = 0;
			for (int i = 0; i < Strings.Count; i++)
			{
				length = length + Strings[i].Length + 1;
			}
			return length;
		}

		private EbxField ReadField(BinaryReader Reader, int FieldIndex)
		{
			EbxField field = new EbxField(this)
			{
				Descriptor = FieldDescriptors[FieldIndex],
				Offset = Reader.BaseStream.Position
			};
			switch (field.Descriptor.FieldType)
			{
			case FieldType.DAI_BaseObjectField:
			case FieldType.DAI_LinkObjectField:
			case FieldType.DAI_ChildObjectField:
			case FieldType.DAI_StructField:
				field.ComplexValue = ReadComplex(Reader, field.Descriptor.ComplexReference);
				break;
			case FieldType.DAI_Bool:
				field.Value = Reader.ReadBoolean();
				break;
			case FieldType.DAI_Byte:
				field.Value = Reader.ReadSByte();
				break;
			case FieldType.DAI_UByte:
				field.Value = Reader.ReadByte();
				break;
			case FieldType.DAI_UShort:
				field.Value = Reader.ReadUInt16();
				break;
			case FieldType.DAI_Short:
				field.Value = Reader.ReadInt16();
				break;
			case FieldType.DAI_UInt:
				field.Value = Reader.ReadUInt32();
				break;
			case FieldType.DAI_Int:
				field.Value = Reader.ReadInt32();
				break;
			case FieldType.DAI_Single:
				field.Value = Reader.ReadSingle();
				break;
			case FieldType.DAI_Long:
				field.Value = Reader.ReadInt64();
				break;
			case FieldType.DAI_ULong:
				field.Value = Reader.ReadUInt64();
				break;
			case FieldType.DAI_Double:
				field.Value = Reader.ReadDouble();
				break;
			case FieldType.DAI_Guid:
				field.Value = Reader.ReadGuid();
				break;
			case FieldType.DAI_String:
			{
				string str1 = "";
				long position1 = Reader.BaseStream.Position;
				int num1 = Reader.ReadInt32();
				if (num1 != -1)
				{
					Reader.BaseStream.Seek((long)Header.StringOffset + (long)num1, SeekOrigin.Begin);
					str1 = Reader.ReadNullTerminatedString();
					Reader.BaseStream.Seek(position1 + 4, SeekOrigin.Begin);
				}
				field.Value = str1;
				break;
			}
			case FieldType.DAI_ExternalID:
				field.Value = Reader.ReadUInt32();
				break;
			case FieldType.DAI_Enum:
			{
				string fieldName = "";
				int num2 = Reader.ReadInt32();
				MemoryStream memoryStream = new MemoryStream();
				memoryStream.Write(BitConverter.GetBytes(num2), 0, 4);
				ComplexObjectDescriptor item = ComplexDescriptors[field.Descriptor.ComplexReference];
				if (item.FieldCount != 0)
				{
					for (int fieldStartIndex = item.FieldStartIndex; fieldStartIndex < item.FieldStartIndex + item.FieldCount; fieldStartIndex++)
					{
						if (FieldDescriptors[fieldStartIndex].PayloadOffset == num2)
						{
							fieldName = FieldDescriptors[fieldStartIndex].FieldName;
							break;
						}
					}
				}
				for (int i = 0; i < fieldName.Length; i++)
				{
					memoryStream.WriteByte((byte)fieldName[i]);
				}
				field.Value = memoryStream.ToArray();
				break;
			}
			case FieldType.DAI_Array:
			{
				bool old = InArray;
				InArray = true;
				int num3 = Reader.ReadInt32();
				ArrayRepeater dAIArrayRepeater = ArrayRepeaters[num3];
				ComplexObjectDescriptor dAIComplexDescriptor = ComplexDescriptors[field.Descriptor.ComplexReference];
				Reader.BaseStream.Seek(Header.ArraySectionStart + dAIArrayRepeater.Offset, SeekOrigin.Begin);
				ComplexObject dAIComplex = new ComplexObject
				{
					Descriptor = dAIComplexDescriptor,
					Offset = Reader.BaseStream.Position
				};
				for (int j = 0; j < dAIArrayRepeater.Count; j++)
				{
					dAIComplex.Fields.Add(ReadField(Reader, dAIComplexDescriptor.FieldStartIndex));
				}
				field.ComplexValue = dAIComplex;
				InArray = old;
				break;
			}
			}
			return field;
		}

		public static EbxBase ReadFromFile(string Filename, EbxRef ebx)
		{
			BinaryReader binaryReader = new BinaryReader(new FileStream(Filename, FileMode.Open, FileAccess.Read));
			EbxBase ebxBase = new EbxBase();
			ebxBase.Read(binaryReader);
			binaryReader.Close();
			return ebxBase;
		}

		public static EbxBase ReadFromStream(Stream s)
		{
			BinaryReader binaryReader = new BinaryReader(s);
			EbxBase ebxBase = new EbxBase();
			ebxBase.Read(binaryReader);
			binaryReader.Close();
			return ebxBase;
		}

		public void Write(BinaryWriter writer)
		{
			writer.Write(new byte[40]);
			writer.Write(FileGuid);
			writer.Write(0L);
			foreach (ExternalGuid externalGuid in ExternalGuids)
			{
				writer.Write(externalGuid.FileGuid);
				writer.Write(externalGuid.InstanceGuid);
			}
			foreach (string value in KeywordDict.Values)
			{
				writer.WriteNullTerminatedString(value);
			}
			while (writer.BaseStream.Position % 16 != 0L)
			{
				writer.Write((byte)0);
			}
			foreach (FieldDescriptor fieldDescriptor in FieldDescriptors)
			{
				fieldDescriptor.Write(writer);
			}
			foreach (ComplexObjectDescriptor complexDescriptor in ComplexDescriptors)
			{
				complexDescriptor.Write(writer);
			}
			foreach (InstanceRepeater instanceRepeater in InstanceRepeaters)
			{
				instanceRepeater.Write(writer);
			}
			while (writer.BaseStream.Position % 16 != 0L)
			{
				writer.Write((byte)0);
			}
			foreach (ArrayRepeater arrayRepeater in ArrayRepeaters)
			{
				arrayRepeater.Write(writer);
			}
			while (writer.BaseStream.Position % 16 != 0L)
			{
				writer.Write((byte)0);
			}
			foreach (string @string in Strings)
			{
				writer.WriteNullTerminatedString(@string);
			}
			while (writer.BaseStream.Position % 16 != 0L)
			{
				writer.Write((byte)0);
			}
			GeneratePayload(writer);
			foreach (ArrayRepeater rep in ArrayRepeaters)
			{
				writer.BaseStream.Seek(Header.ArraySectionStart + rep.Offset - 4, SeekOrigin.Begin);
				writer.Write(rep.Count);
			}
			writer.BaseStream.Seek(0L, SeekOrigin.End);
			while (writer.BaseStream.Length < Header.StringOffset + Header.StringLengthToEOF)
			{
				writer.Write((byte)0);
			}
			writer.BaseStream.Position = 0L;
			writer.Write(263377358);
			Header.Write(writer);
		}

		private void GeneratePayload(BinaryWriter writer)
		{
			int instanceIndex = 0;
			int repeaterIndex = 0;
			for (int i = 0; i < InstanceRepeaters.Count; i++)
			{
				for (int j = 0; j < InstanceRepeaters[i].Count; j++)
				{
					ComplexObject obj = Instances.ElementAt(instanceIndex).Value;
					Guid g = Instances.ElementAt(instanceIndex).Key;
					if (repeaterIndex < Header.GuidRepeaterCount)
					{
						writer.Seek((int)obj.Offset - 16, SeekOrigin.Begin);
						writer.Write(g);
					}
					WriteComplexObject(obj, writer, true);
					instanceIndex++;
				}
				repeaterIndex++;
			}
			Payload = new byte[Header.PayloadLength];
		}

		private void WriteComplexObject(ComplexObject obj, BinaryWriter writer, bool IsInstance)
		{
			if (obj == null)
			{
				return;
			}
			foreach (EbxField field in obj.Fields)
			{
				WriteField(field, writer);
			}
		}

		private void WriteField(EbxField field, BinaryWriter writer)
		{
			writer.Seek((int)field.Offset, SeekOrigin.Begin);
			switch (field.Descriptor.FieldType)
			{
			case FieldType.DAI_Bool:
				writer.Write((bool)field.Value);
				break;
			case FieldType.DAI_Byte:
				writer.Write((sbyte)field.Value);
				break;
			case FieldType.DAI_UByte:
				writer.Write((byte)field.Value);
				break;
			case FieldType.DAI_Short:
				writer.Write((short)field.Value);
				break;
			case FieldType.DAI_UShort:
				writer.Write((ushort)field.Value);
				break;
			case FieldType.DAI_Int:
				writer.Write((int)field.Value);
				break;
			case FieldType.DAI_UInt:
				writer.Write((uint)field.Value);
				break;
			case FieldType.DAI_Single:
				writer.Write((float)field.Value);
				break;
			case FieldType.DAI_ExternalID:
				writer.Write((uint)field.Value);
				break;
			case FieldType.DAI_Long:
				writer.Write((long)field.Value);
				break;
			case FieldType.DAI_ULong:
				writer.Write((ulong)field.Value);
				break;
			case FieldType.DAI_Double:
				writer.Write((double)field.Value);
				break;
			case FieldType.DAI_String:
			{
				string str = (string)field.Value;
				if (string.IsNullOrEmpty(str))
				{
					writer.Write(uint.MaxValue);
					break;
				}
				int length = 0;
				for (int j = 0; j < Strings.Count; j++)
				{
					if (Strings[j].CompareTo(str) == 0)
					{
						writer.Write(length);
						break;
					}
					length += Strings[j].Length + 1;
				}
				break;
			}
			case FieldType.DAI_Array:
			{
				for (int i = 0; i < ArrayRepeaters.Count; i++)
				{
					if (ArrayRepeaters[i].Offset + Header.ArraySectionStart == field.ComplexValue.Offset)
					{
						writer.Write(i);
						break;
					}
				}
				break;
			}
			case FieldType.DAI_Enum:
				writer.Write(field.GetEnumIntValue());
				break;
			}
			if (field.ComplexValue != null)
			{
				WriteComplexObject(field.ComplexValue, writer, false);
			}
		}

		public string ToXml(bool bIncludeExtraMeta = true)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				using (IStructuredWriter writer = new YAMLStructuredWriter(ms))
				{
					ToDocument(writer, bIncludeExtraMeta);
				}
				using (StreamReader reader = new StreamReader(ms, Encoding.UTF8, true))
				{
					ms.Seek(0L, SeekOrigin.Begin);
					return reader.ReadToEnd();
				}
			}
		}

		public void ToDocument(IStructuredWriter writer, bool bIncludeExtraMeta = true, bool guidAsInvertedStrings = false)
		{
			writer.WriteStartDocument();
			writer.WriteStartElement("EbxFile");
			writer.WriteAttributeString("Guid", FileGuid.ToString(guidAsInvertedStrings));
			for (int i = 0; i < Instances.Count; i++)
			{
				Guid dQWord = Instances.Keys.ElementAt(i);
				ComplexObject dAIComplex = Instances.Values.ElementAt(i);
				writer.WriteStartElement(dAIComplex.Descriptor.FieldName);
				writer.WriteAttributeString("Guid", dQWord.ToString(guidAsInvertedStrings));
				if (bIncludeExtraMeta)
				{
					writer.WriteAttributeString("Offset", "0x" + dAIComplex.Offset.ToString("X8"));
				}
				dAIComplex.ToXml(writer, bIncludeExtraMeta, false, guidAsInvertedStrings);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
			writer.WriteEndDocument();
			writer.Flush();
		}

		public void WriteToFile(string Filename)
		{
			BinaryWriter binaryWriter = new BinaryWriter(new FileStream(Filename, FileMode.Create));
			Write(binaryWriter);
			binaryWriter.Close();
		}

		public MemoryStream WriteToStream()
		{
			MemoryStream memoryStream = new MemoryStream();
			Write(new BinaryWriter(memoryStream));
			return memoryStream;
		}

		private static void ToHexFile(byte[] data)
		{
			StringBuilder sb = new StringBuilder();
			StringBuilder dataSB = new StringBuilder();
			for (int i = 0; i < data.Length; i++)
			{
				if (i % 16 == 0)
				{
					if (sb.Length != 0)
					{
						sb.AppendLine(dataSB.ToString());
					}
					sb.AppendFormat("{0:D8}   {0:X8}     ", i);
					dataSB.Clear();
				}
				if (i % 8 == 0)
				{
					dataSB.Append("  ");
				}
				dataSB.AppendFormat("{0:X2} ", data[i]);
			}
			sb.AppendLine(dataSB.ToString());
			using (FileStream fs = new FileStream("C:\\temp\\hexfile.txt", FileMode.Create, FileAccess.Write))
			{
				using (StreamWriter writer = new StreamWriter(fs))
				{
					writer.Write(sb.ToString());
				}
			}
		}

		private int Hasher(string StrToHash)
		{
			int num = 5381;
			for (int i = 0; i < StrToHash.Length; i++)
			{
				byte strToHash = (byte)StrToHash[i];
				num = (num * 33) ^ strToHash;
			}
			return num;
		}

		private bool HasKeyword(string InKeyword)
		{
			return KeywordDict.ContainsKey(InKeyword.Hash());
		}

		public void AddKeyword(string InKeyword)
		{
			int hash = Hasher(InKeyword);
			if (!KeywordDict.ContainsKey(hash))
			{
				KeywordDict.Add(hash, InKeyword);
			}
		}
	}
}

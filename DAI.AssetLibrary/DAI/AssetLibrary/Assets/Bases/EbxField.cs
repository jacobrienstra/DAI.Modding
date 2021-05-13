using System;
using System.Text;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary.Assets.Bases
{
	public class EbxField
	{
		public FieldDescriptor Descriptor { get; set; }

		public long Offset { get; set; }

		public object Value { get; set; }

		public ComplexObject ComplexValue { get; set; }

		public EbxBase EbxFile { get; set; }

		public EbxField(EbxBase parent)
		{
			EbxFile = parent;
		}

		public int GetEnumIntValue()
		{
			return BitConverter.ToInt32((byte[])Value, 0);
		}

		public string GetEnumStringValue()
		{
			byte[] bytes = (byte[])Value;
			StringBuilder sb = new StringBuilder();
			for (int i = 4; i < bytes.Length; i++)
			{
				sb.Append((char)bytes[i]);
			}
			return sb.ToString();
		}

		public ExternalGuid GetValueAsGuid()
		{
			ExternalGuid dAIExternalGuid = null;
			uint uIntValue = (uint)Value;
			if (uIntValue >> 31 != 1)
			{
				if (uIntValue == 0)
				{
					return new ExternalGuid(Guid.Empty, Guid.Empty);
				}
				int index = (int)(uIntValue - 1);
				return new ExternalGuid(Guid.Empty, EbxFile.InternalGuids[index]);
			}
			return EbxFile.ExternalGuids[(int)(uIntValue & 0x7FFFFFFF)];
		}

		public decimal NumericValue()
		{
			switch (Descriptor.FieldType)
			{
			case FieldType.DAI_Long:
			case FieldType.DAI_Byte:
			case FieldType.DAI_UByte:
			case FieldType.DAI_UShort:
			case FieldType.DAI_Short:
			case FieldType.DAI_Int:
			case FieldType.DAI_UInt:
			case FieldType.DAI_ULong:
			case FieldType.DAI_Single:
			case FieldType.DAI_Double:
				return Convert.ToDecimal(Value);
			default:
				return 0m;
			}
		}

		public void SetNumericValue(decimal value)
		{
			switch (Descriptor.FieldType)
			{
			case FieldType.DAI_Int:
				Value = Convert.ToInt32(value);
				break;
			case FieldType.DAI_UInt:
				Value = Convert.ToUInt32(value);
				break;
			case FieldType.DAI_Single:
				Value = Convert.ToSingle(value);
				break;
			case FieldType.DAI_Short:
				Value = Convert.ToInt16(value);
				break;
			case FieldType.DAI_UShort:
				Value = Convert.ToUInt16(value);
				break;
			case FieldType.DAI_Byte:
				Value = Convert.ToSByte(value);
				break;
			case FieldType.DAI_UByte:
				Value = Convert.ToByte(value);
				break;
			case FieldType.DAI_ULong:
				Value = Convert.ToUInt64(value);
				break;
			case FieldType.DAI_Long:
				Value = Convert.ToInt64(value);
				break;
			case FieldType.DAI_Double:
				Value = Convert.ToDouble(value);
				break;
			}
		}

		public void ToPlotFlagXml(IStructuredWriter writer, bool bIncludeExtraMeta = true)
		{
			if (Descriptor.FieldName == "$")
			{
				ComplexValue.ToXml(writer);
				return;
			}
			writer.WriteStartElement(Descriptor.FieldName);
			if (bIncludeExtraMeta)
			{
				writer.WriteAttributeString("Offset", "0x" + Offset.ToString("X8"));
				writer.WriteAttributeString("Type", ((ushort)Descriptor.FieldType).ToString());
			}
			Guid longLongValue = (Guid)Value;
			writer.WriteValue(Library.GetPlotFlag(longLongValue));
			writer.WriteEndElement();
		}

		public void ToXml(IStructuredWriter writer, bool bIncludeExtraMeta = true, bool guidAsInvertedStrings = false)
		{
			if (Descriptor.FieldName == "$")
			{
				ComplexValue.ToXml(writer, bIncludeExtraMeta);
				return;
			}
			writer.WriteStartElement(Descriptor.FieldName);
			if (bIncludeExtraMeta)
			{
				writer.WriteAttributeString("Offset", "0x" + Offset.ToString("X8"));
				writer.WriteAttributeString("Type", Descriptor.FieldType.ToString());
			}
			switch (Descriptor.FieldType)
			{
			case FieldType.DAI_BaseObjectField:
			case FieldType.DAI_LinkObjectField:
			case FieldType.DAI_Array:
			case FieldType.DAI_ChildObjectField:
			case FieldType.DAI_StructField:
				if (ComplexValue != null)
				{
					if (ComplexValue.Descriptor.FieldName != "PlotFlagId")
					{
						ComplexValue.ToXml(writer, bIncludeExtraMeta);
					}
					else
					{
						ComplexValue.ToPlotFlagXml(writer, bIncludeExtraMeta);
					}
				}
				writer.WriteEndElement();
				return;
			case FieldType.DAI_Int:
				if (Descriptor.FieldName == "StringId")
				{
					uint uIntValue = Convert.ToUInt32(Value);
					Talktable.TalktableString sTR = Library.GetString(Library.DefaultLanguage, uIntValue);
					writer.WriteValue((sTR != null) ? sTR.SanitizedDisplayValue : "");
				}
				else if (!Descriptor.FieldName.Contains("Id"))
				{
					writer.WriteValue(((int)Value).ToString(), this);
				}
				else
				{
					writer.WriteValue(Library.GetEvent((int)Value));
				}
				break;
			case FieldType.DAI_ExternalID:
			{
				uint uIntValue2 = (uint)Value;
				if (uIntValue2 >> 31 != 1)
				{
					if (uIntValue2 != 0)
					{
						Guid item = EbxFile.InternalGuids[(int)(uIntValue2 - 1)];
						writer.WriteValue("[" + EbxFile.Instances[item].GetName() + "] " + item.ToString(guidAsInvertedStrings));
					}
					break;
				}
				ExternalGuid dAIExternalGuid = EbxFile.ExternalGuids[(int)(uIntValue2 & 0x7FFFFFFF)];
				EbxRef ebx = Library.GetEbxByGuid(dAIExternalGuid.FileGuid);
				EbxBase dAIEbx = EbxBase.FromEbx(ebx);
				if (dAIEbx == null)
				{
					writer.WriteValue(string.Concat("Unable to resolve at this time (", dAIExternalGuid.FileGuid, ")"));
				}
				else
				{
					writer.WriteValue("[" + dAIEbx.Instances[dAIExternalGuid.InstanceGuid].GetName() + "] " + ebx.Name, this);
				}
				break;
			}
			case FieldType.DAI_String:
			case FieldType.DAI_Long:
			case FieldType.DAI_Enum:
			case FieldType.DAI_Bool:
			case FieldType.DAI_Byte:
			case FieldType.DAI_UByte:
			case FieldType.DAI_UShort:
			case FieldType.DAI_Short:
			case FieldType.DAI_UInt:
			case FieldType.DAI_ULong:
			case FieldType.DAI_Single:
			case FieldType.DAI_Double:
			case FieldType.DAI_Guid:
				writer.WriteValue(ValueToString(), this);
				break;
			}
			writer.WriteEndElement();
		}

		private string ValueToString()
		{
			switch (Descriptor.FieldType)
			{
			case FieldType.DAI_String:
				return ((string)Value).Replace("/", "//");
			case FieldType.DAI_Enum:
				return GetEnumStringValue();
			case FieldType.DAI_UInt:
				return ((uint)Value).ToString("X8");
			case FieldType.DAI_Single:
				return ((float)Value).ToString("F3");
			case FieldType.DAI_Short:
				return ((short)Value).ToString("X4");
			case FieldType.DAI_UShort:
				return ((ushort)Value).ToString("X4");
			case FieldType.DAI_Byte:
				return ((sbyte)Value).ToString("X2");
			case FieldType.DAI_UByte:
				return ((byte)Value).ToString("X2");
			case FieldType.DAI_ULong:
				return ((ulong)Value).ToString("X16");
			case FieldType.DAI_Long:
				return ((long)Value).ToString("X16");
			case FieldType.DAI_Guid:
				return ((Guid)Value).ToString();
			case FieldType.DAI_Double:
				return ((double)Value).ToString("F6");
			case FieldType.DAI_Bool:
				return ((bool)Value).ToString();
			default:
				throw new NotSupportedException();
			}
		}
	}
}

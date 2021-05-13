using System.Collections.Generic;
using DAI.AssetLibrary.Utilities;

namespace DAI.AssetLibrary.Assets.Bases
{
	public class ComplexObject
	{
		public ComplexObjectDescriptor Descriptor { get; set; }

		public long Offset { get; set; }

		public List<EbxField> Fields { get; private set; }

		public ComplexObject()
		{
			Fields = new List<EbxField>();
		}

		public EbxField GetFieldByName(string FieldName)
		{
			return Fields.Find((EbxField x) => x.Descriptor.FieldName == FieldName);
		}

		public bool HasField(string fieldName)
		{
			return Fields.Find((EbxField x) => x.Descriptor.FieldName == fieldName) != null;
		}

		public string GetName()
		{
			return Descriptor.FieldName;
		}

		public void ToPlotFlagXml(IStructuredWriter writer, bool bIncludeExtraMeta = true, bool bPrintDescriptor = true)
		{
			if (bPrintDescriptor && Descriptor.FieldName != "array")
			{
				writer.WriteStartElement(Descriptor.FieldName);
				if (bIncludeExtraMeta)
				{
					writer.WriteAttributeString("Offset", "0x" + Offset.ToString("X8"));
				}
			}
			foreach (EbxField field in Fields)
			{
				field.ToPlotFlagXml(writer, bIncludeExtraMeta);
			}
			if (bPrintDescriptor && Descriptor.FieldName != "array")
			{
				writer.WriteEndElement();
			}
		}

		public void ToXml(IStructuredWriter writer, bool bIncludeExtraMeta = true, bool bPrintDescriptor = true, bool guidAsInvertedStrings = false)
		{
			if (Descriptor.FieldName == "array")
			{
				writer.StartArray(this);
			}
			else if (bPrintDescriptor)
			{
				writer.WriteStartElement(Descriptor.FieldName);
				if (bIncludeExtraMeta)
				{
					writer.WriteAttributeString("Offset", "0x" + Offset.ToString("X8"));
				}
			}
			foreach (EbxField field in Fields)
			{
				field.ToXml(writer, bIncludeExtraMeta, guidAsInvertedStrings);
			}
			if (Descriptor.FieldName == "array")
			{
				writer.EndArray();
			}
			else if (bPrintDescriptor)
			{
				writer.WriteEndElement();
			}
		}
	}
}

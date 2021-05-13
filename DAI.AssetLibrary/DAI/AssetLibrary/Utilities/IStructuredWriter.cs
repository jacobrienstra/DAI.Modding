using System;
using DAI.AssetLibrary.Assets.Bases;

namespace DAI.AssetLibrary.Utilities
{
	public interface IStructuredWriter : IDisposable
	{
		void Close();

		void Flush();

		void WriteStartDocument();

		void WriteEndDocument();

		void WriteStartElement(string localName);

		void WriteEndElement();

		void WriteValue(string value);

		void WriteValue(string value, EbxField backingField);

		void WriteAttributeString(string localName, string value);

		void StartArray(ComplexObject array);

		void EndArray();
	}
}

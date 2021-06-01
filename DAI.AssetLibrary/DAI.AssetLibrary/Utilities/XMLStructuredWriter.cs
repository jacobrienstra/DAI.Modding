using System;
using System.IO;
using System.Xml;

using DAI.AssetLibrary.Assets.Bases;

namespace DAI.AssetLibrary.Utilities {
    public class XMLStructuredWriter : IStructuredWriter, IDisposable {
        private XmlWriter _xmlWriter;

        public XMLStructuredWriter(Stream output) {
            _xmlWriter = XmlWriter.Create(output, new XmlWriterSettings {
                Indent = true
            });
        }

        public void Close() {
            _xmlWriter.Close();
        }

        public void Flush() {
            _xmlWriter.Flush();
        }

        public void WriteStartDocument() {
            _xmlWriter.WriteStartDocument();
        }

        public void WriteEndDocument() {
            _xmlWriter.WriteEndDocument();
        }

        public void WriteStartElement(string localName) {
            _xmlWriter.WriteStartElement(localName);
        }

        public void WriteEndElement() {
            _xmlWriter.WriteEndElement();
        }

        public void WriteValue(string value) {
            _xmlWriter.WriteValue(value);
        }

        public void WriteValue(string value, EbxField backingField) {
            _xmlWriter.WriteValue(value);
        }

        public void WriteAttributeString(string localName, string value) {
            _xmlWriter.WriteAttributeString(localName, value);
        }

        public void StartArray(ComplexObject array) {
        }

        public void EndArray() {
        }

        public void Dispose() {
            ((IDisposable)_xmlWriter).Dispose();
        }
    }
}

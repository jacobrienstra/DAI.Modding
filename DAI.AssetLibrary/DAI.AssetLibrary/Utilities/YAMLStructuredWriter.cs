using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using DAI.AssetLibrary.Assets.Bases;

namespace DAI.AssetLibrary.Utilities {
    public class YAMLStructuredWriter : IStructuredWriter, IDisposable {
        private Stream _stream;

        private int _indent;

        private Queue<string> _pendingAttributes = new Queue<string>();

        public YAMLStructuredWriter(Stream output) {
            _stream = output;
        }

        public void Close() {
            _stream.Close();
        }

        public void Flush() {
            FlushPendingAttributes();
            _stream.Flush();
        }

        public void WriteStartDocument() {
            WriteString("---");
        }

        public void WriteEndDocument() {
            FlushPendingAttributes();
            WriteLine("...");
        }

        public void WriteStartElement(string localName) {
            FlushPendingAttributes();
            WriteLine(localName + "\t: ");
            _indent++;
        }

        public void WriteEndElement() {
            FlushPendingAttributes();
            _indent--;
        }

        public void WriteValue(string value) {
            WriteString(value);
        }

        public void WriteValue(string value, EbxField backingField) {
            WriteString(value);
        }

        public void WriteAttributeString(string localName, string value) {
            _pendingAttributes.Enqueue("@" + localName + "\t: " + value);
        }

        public void StartArray(ComplexObject array) {
        }

        public void EndArray() {
        }

        public void Dispose() {
        }

        private void FlushPendingAttributes() {
            while (_pendingAttributes.Count > 0) {
                WriteLine(_pendingAttributes.Dequeue());
            }
        }

        private void WriteLine(string str) {
            string indent = new string(' ', _indent * 2);
            WriteString("\r\n" + indent + str);
        }

        private void WriteString(string str) {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            _stream.Write(bytes, 0, bytes.Length);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Utilities;
using DAI.Mod.Maker.Controls;

namespace DAI.Mod.Maker.Utilities {
    public class YamlFlowDocumentWriter : IStructuredWriter, IDisposable {
        private FlowDocument _document;

        private int _indent;

        private Paragraph _currentParagraph;

        private Brush _attributeBrush;

        private Queue<string> _pendingAttributes = new Queue<string>();

        private Stack<ComplexObject> _arrayContainer = new Stack<ComplexObject>();

        public bool EditMode { get; set; }

        public YamlFlowDocumentWriter(FlowDocument output) {
            _document = output;
            _attributeBrush = new SolidColorBrush(Color.FromRgb(100, 100, 100));
        }

        public void Close() {
        }

        public void Flush() {
            FlushPendingAttributes();
        }

        public void WriteStartDocument() {
            AddLine("---");
        }

        public void WriteEndDocument() {
            FlushPendingAttributes();
            AddLine("...");
        }

        public void WriteStartElement(string localName) {
            FlushPendingAttributes();
            AddLine(localName + "\t: ");
            _arrayContainer.Push(null);
            _indent++;
        }

        public void WriteEndElement() {
            FlushPendingAttributes();
            _arrayContainer.Pop();
            _indent--;
        }

        public void WriteValue(string value) {
            WriteString(value).FontWeight = FontWeights.Bold;
        }

        public void WriteValue(string value, EbxField backingField) {
            if (EditMode && NumericUpDown.IsTypeSupported(backingField.Descriptor.FieldType)) {
                InlineUIContainer container = new InlineUIContainer(new NumericUpDown(backingField));
                container.BaselineAlignment = BaselineAlignment.Center;
                _currentParagraph.Inlines.Add(container);
            } else if (backingField.Descriptor.FieldType == FieldType.DAI_ExternalID) {
                Hyperlink link = new Hyperlink(new Run(value));
                link.Tag = backingField.GetValueAsGuid();
                _currentParagraph.Inlines.Add(link);
            } else {
                WriteValue(value);
            }
        }

        public void WriteAttributeString(string localName, string value) {
            _pendingAttributes.Enqueue("@" + localName + "\t: " + value);
        }

        public void StartArray(ComplexObject array) {
            _arrayContainer.Push(array);
            _indent++;
        }

        public void EndArray() {
            _arrayContainer.Pop();
            _indent--;
        }

        public void Dispose() {
        }

        private void FlushPendingAttributes() {
            while (_pendingAttributes.Count > 0) {
                AddLine(_pendingAttributes.Dequeue()).Foreground = _attributeBrush;
            }
        }

        private Run AddLine(string str) {
            _currentParagraph = new Paragraph();
            if (_arrayContainer.Count > 0 && _arrayContainer.Peek() != null) {
                _currentParagraph.TextIndent = (_indent - 1) * 15;
                WriteString("- ");
            } else {
                _currentParagraph.TextIndent = _indent * 15;
            }
            _document.Blocks.Add(_currentParagraph);
            return WriteString(str);
        }

        private Run WriteString(string str) {
            Run run = new Run(str);
            _currentParagraph.Inlines.Add(run);
            return run;
        }
    }
}

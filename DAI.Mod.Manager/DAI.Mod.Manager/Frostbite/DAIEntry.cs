using System.Collections.Generic;
using System.IO;
using System.Linq;

using DAI.Mod.Manager.Utilities;

namespace DAI.Mod.Manager.Frostbite {
    public class DAIEntry {
        public byte EntryType;

        public int EntrySize;

        public int EntryOffset;

        private Dictionary<string, DAIField> Fields;

        private List<DAIField> _orderedFields = new List<DAIField>();

        public DAIEntry(byte InEntryType, int InEntrySize, int InEntryOffset) {
            EntryType = InEntryType;
            EntrySize = InEntrySize;
            EntryOffset = InEntryOffset;
            Fields = new Dictionary<string, DAIField>();
        }

        public DAIEntry() {
            Fields = new Dictionary<string, DAIField>();
        }

        public bool HasField(string FieldName) {
            return Fields.ContainsKey(FieldName);
        }

        public long GetQWordValue(string FieldName) {
            return ((QWordField)Fields[FieldName]).QWordValue;
        }

        public DQWord GetDQWordValue(string FieldName) {
            return ((DQWordField)Fields[FieldName]).DQWordValue;
        }

        public int GetDWordValue(string FieldName) {
            return ((DWordField)Fields[FieldName]).DWordValue;
        }

        public List<DAIEntry> GetListValue(string FieldName) {
            return ((ListField)Fields[FieldName]).ChildEntries;
        }

        public string GetStringValue(string FieldName) {
            return ((StringField)Fields[FieldName]).StringValue;
        }

        public Sha1 GetStringHashValue(string FieldName) {
            return ((StringField)Fields[FieldName]).StringHash;
        }

        public Sha1 GetSha1Value(string FieldName) {
            return ((Sha1Field)Fields[FieldName]).Sha1Value;
        }

        public byte[] GetByteArrayValue(string FieldName) {
            return ((ByteArrayField)Fields[FieldName]).ByteValue;
        }

        public bool GetBoolValue(string FieldName) {
            return ((BoolField)Fields[FieldName]).BoolValue;
        }

        public void SetSha1Value(string FieldName, Sha1 Value) {
            ((Sha1Field)Fields[FieldName]).Sha1Value = Value;
        }

        public void SetQWordValue(string FieldName, long Value) {
            ((QWordField)Fields[FieldName]).QWordValue = Value;
        }

        public void SetDQWordValue(string FieldName, DQWord Value) {
            ((DQWordField)Fields[FieldName]).DQWordValue = Value;
        }

        public void SetDWordValue(string FieldName, uint Value) {
            ((DWordField)Fields[FieldName]).DWordValue = (int)Value;
        }

        public void SetStringValue(string FieldName, string Value) {
            ((StringField)Fields[FieldName]).StringValue = Value;
        }

        public void SetByteArrayValue(string FieldName, byte[] Value) {
            ((ByteArrayField)Fields[FieldName]).ByteValue = Value;
        }

        public void SetListChild(string FieldName, int Index, DAIEntry ChildValue) {
            ((ListField)Fields[FieldName]).ChildEntries[Index] = ChildValue;
        }

        public void AddSha1Value(string FieldName, Sha1 Value) {
            Sha1Field sha1Field = new Sha1Field();
            sha1Field.FieldName = FieldName;
            sha1Field.Sha1Value = Value;
            AddField(FieldName, sha1Field);
        }

        public void AddQWordValue(string FieldName, long Value) {
            QWordField qWordField = new QWordField();
            qWordField.FieldName = FieldName;
            qWordField.QWordValue = Value;
            AddField(FieldName, qWordField);
        }

        public void AddDQWordValue(string FieldName, DQWord Value) {
            DQWordField dQWordField = new DQWordField();
            dQWordField.FieldName = FieldName;
            dQWordField.DQWordValue = Value;
            AddField(FieldName, dQWordField);
        }

        public void AddDWordValue(string FieldName, uint Value) {
            DWordField dWordField = new DWordField();
            dWordField.FieldName = FieldName;
            dWordField.DWordValue = (int)Value;
            AddField(FieldName, dWordField);
        }

        public void AddStringValue(string FieldName, string Value) {
            StringField stringField = new StringField();
            stringField.FieldName = FieldName;
            stringField.StringValue = Value;
            AddField(FieldName, stringField);
        }

        public DAIField AddByteArrayValue(string FieldName, byte[] Value) {
            ByteArrayField byteArrayField = new ByteArrayField();
            byteArrayField.FieldName = FieldName;
            byteArrayField.ByteValue = Value;
            AddField(FieldName, byteArrayField);
            return byteArrayField;
        }

        public void AddBoolValue(string FieldName, bool Value) {
            BoolField boolField = new BoolField();
            boolField.FieldName = FieldName;
            boolField.BoolValue = Value;
            AddField(FieldName, boolField);
        }

        public void AddListValue(string FieldName, List<DAIEntry> Value = null) {
            ListField listField = new ListField();
            listField.FieldName = FieldName;
            listField.ChildEntries = Value ?? new List<DAIEntry>();
            AddField(FieldName, listField);
        }

        public void AddListChild(string FieldName, DAIEntry ChildValue) {
            ((ListField)Fields[FieldName]).AddChild(ChildValue);
        }

        public void AddListStringChild(string FieldName, string Value) {
            ((ListField)Fields[FieldName]).AddChild(new DAIStringEntry {
                StringValue = Value
            });
        }

        public void AddField(string FieldName, DAIField FieldValue) {
            Fields.Add(FieldName, FieldValue);
            _orderedFields.Add(FieldValue);
        }

        public void RemoveField(string FieldName) {
            if (Fields.ContainsKey(FieldName)) {
                _orderedFields.Remove(Fields[FieldName]);
                Fields.Remove(FieldName);
            }
        }

        public virtual int GetSize() {
            int entrySize = GetEntrySize();
            return entrySize + DAIToc.GetSize128(entrySize) + 1;
        }

        private int GetEntrySize() {
            int num = Fields.Values.Sum((DAIField daiField) => daiField.GetSize());
            return num + 1;
        }

        public virtual void Write(BinaryWriter Writer) {
            EntryOffset = (int)Writer.BaseStream.Position;
            Writer.Write((byte)130);
            DAIToc.Write128(Writer, GetEntrySize());
            foreach (DAIField value in Fields.Values) {
                value.Write(Writer);
            }
            Writer.Write((byte)0);
        }
    }
}

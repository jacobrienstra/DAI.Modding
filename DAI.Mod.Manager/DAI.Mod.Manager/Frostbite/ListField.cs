using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAI.ModManager.Frostbite {
    public class ListField : DAIField {
        public List<DAIEntry> ChildEntries;

        public int ListSize;

        public ListField() {
            DataType = 1;
        }

        public override int GetSize() {
            int listSize = GetListSize();
            return base.GetSize() + DAIToc.GetSize128(listSize) + listSize;
        }

        private int GetListSize() {
            int num = ChildEntries.Sum((DAIEntry daiEntry) => daiEntry.GetSize());
            return num + 1;
        }

        public override void Write(BinaryWriter Writer) {
            base.Write(Writer);
            DAIToc.Write128(Writer, GetListSize());
            foreach (DAIEntry childEntry in ChildEntries) {
                childEntry.Write(Writer);
            }
            Writer.Write((byte)0);
        }

        public void AddChild(DAIEntry Entry) {
            ChildEntries.Add(Entry);
        }

        public override string ToString() {
            return "< " + FieldName + " (len=" + ChildEntries.Count + ") >";
        }
    }
}

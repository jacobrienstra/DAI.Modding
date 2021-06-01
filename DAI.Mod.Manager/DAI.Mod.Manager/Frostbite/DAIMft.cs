using System.Collections.Generic;
using System.IO;

namespace DAI.Mod.Manager.Frostbite {
    public class DAIMft {
        private Dictionary<string, object> KeyValues;

        public DAIMft() {
            KeyValues = new Dictionary<string, object>();
        }

        public string GetValue(string InKey) {
            if (KeyValues.ContainsKey(InKey)) {
                return (string)KeyValues[InKey];
            }
            return "";
        }

        public bool HasKey(string InKey) {
            return KeyValues.ContainsKey(InKey);
        }

        public void Serialize(StreamReader Reader) {
            while (!Reader.EndOfStream) {
                string text = Reader.ReadLine();
                string text2 = "";
                if (text.IndexOf(' ') > -1) {
                    text2 = text.Substring(text.IndexOf(' ') + 1);
                    text = text.Substring(0, text.IndexOf(' '));
                }
                if (KeyValues.ContainsKey(text)) {
                    KeyValues[text] = new List<object>
                    {
                        KeyValues[text],
                        text2
                    };
                } else {
                    KeyValues.Add(text, text2);
                }
            }
        }

        public static DAIMft SerializeFromFile(string Filename) {
            DAIMft dAIMft = new DAIMft();
            StreamReader streamReader = new StreamReader(Filename);
            dAIMft.Serialize(streamReader);
            streamReader.Close();
            return dAIMft;
        }
    }
}

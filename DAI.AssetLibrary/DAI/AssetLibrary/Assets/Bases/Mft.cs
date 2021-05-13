using System.Collections.Generic;
using System.IO;

namespace DAI.AssetLibrary.Assets.Bases
{
	public class Mft
	{
		private Dictionary<string, object> KeyValues;

		public Mft()
		{
			KeyValues = new Dictionary<string, object>();
		}

		public string GetValue(string InKey)
		{
			if (!KeyValues.ContainsKey(InKey))
			{
				return "";
			}
			return (string)KeyValues[InKey];
		}

		public bool HasKey(string InKey)
		{
			if (KeyValues.ContainsKey(InKey))
			{
				return true;
			}
			return false;
		}

		public void Serialize(StreamReader Reader)
		{
			while (!Reader.EndOfStream)
			{
				string str = Reader.ReadLine();
				string str2 = "";
				if (str.IndexOf(' ') > -1)
				{
					string text = str;
					str2 = text.Substring(text.IndexOf(' ') + 1);
					str = str.Substring(0, str.IndexOf(' '));
				}
				if (!KeyValues.ContainsKey(str))
				{
					KeyValues.Add(str, str2);
					continue;
				}
				List<object> objs = new List<object>
				{
					KeyValues[str],
					str2
				};
				KeyValues[str] = objs;
			}
		}

		public static Mft SerializeFromFile(string Filename)
		{
			Mft mft = new Mft();
			StreamReader streamReader = new StreamReader(Filename);
			mft.Serialize(streamReader);
			streamReader.Close();
			return mft;
		}
	}
}

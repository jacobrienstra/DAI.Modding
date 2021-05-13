using System;
using System.Globalization;
using System.Xml;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.ModMaker.DAIMod
{
	public abstract class ModResourceEntry
	{
		public string Name;

		public string NameHash;

		public string Type;

		public string Action;

		public string OriginalSha1;

		public string NewSha1;

		public int ResourceID;

		public long OriginalSize;

		public long Size;

		public byte PatchType;

		public string DeltaSha1;

		public string BaseSha1;

		public bool IsEnabled;

		public ModResourceEntry(string InName, string InType, string InAction)
		{
			Name = InName;
			NameHash = Name.ToSha1();
			Type = InType;
			Action = InAction;
			IsEnabled = true;
		}

		public ModResourceEntry(string type)
		{
			Type = type;
			IsEnabled = true;
		}

		public ModResourceEntry(XmlAttributeCollection attributes, string type)
			: this(type)
		{
			foreach (XmlAttribute attribute in attributes)
			{
				string attributeName = attribute.Name;
				if (attributeName == null)
				{
					continue;
				}
				switch (attributeName.ToLower())
				{
					case "name":
						Name = attribute.Value;
						NameHash = attribute.Value.ToSha1();
						break;
					case "type":
						Type = attribute.Value;
						break;
					case "action":
						Action = attribute.Value;
						break;
					case "originalsha1":
						OriginalSha1 = attribute.Value;
						break;
					case "sha1":
						if (Action == "delete")
						{
							NewSha1 = attribute.Value;
						}
						else
						{
							OriginalSha1 = attribute.Value;
						}
						break;
					case "resourceid":
						ResourceID = Convert.ToInt32(attribute.Value);
						break;
					case "originalsize":
						OriginalSize = Convert.ToInt64(attribute.Value);
						break;
					case "size":
						Size = Convert.ToInt64(attribute.Value);
						break;
					case "patch":
						PatchType = Convert.ToByte(attribute.Value);
						break;
					case "deltasha1":
						DeltaSha1 = attribute.Value;
						break;
					case "basesha1":
						{
							char[] numArray3 = new char[20];
							string value3 = attribute.Value;
							for (int i = 0; i < 40; i += 2)
							{
								string str6 = value3.Substring(0, 2);
								value3 = value3.Remove(0, 2);
								char num5 = (char)byte.Parse(str6, NumberStyles.HexNumber);
								numArray3[i / 2] = num5;
							}
							BaseSha1 = new string(numArray3);
							break;
						}
				}
			}
		}

		protected string Get20Sha1From40Sha1(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new Exception(String.Format("File {0} does not have sha1", Name));
			}
			char[] bytes = new char[20];
			for (int i = 0; i < 40; i += 2)
			{
				string s = value.Substring(0, 2);
				value = value.Remove(0, 2);
				char num4 = (char)byte.Parse(s, NumberStyles.HexNumber);
				bytes[i / 2] = num4;
			}
			return new string(bytes);
		}
	}
}

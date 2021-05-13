using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary.Parsers
{
	internal static class EntriesParser
	{
		internal static bool ParseEntry<T>(this BinaryReader reader, T entry) where T : EntryRef
		{
			int startPosition = (int)reader.BaseStream.Position;
			byte entryType = reader.ReadByte();
			if (entryType != 130 && entryType != 135)
			{
				return false;
			}
			ulong size = reader.ReadEncodedSize();
			entry.EntryOffset = startPosition;
			if (entryType == 130)
			{
				ParseJsonEntry(reader, entry, startPosition, (int)size);
			}
			else
			{
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < (int)size; i++)
				{
					byte b = reader.ReadByte();
					if (b != 0)
					{
						sb.Append((char)b);
					}
				}
				entry.BinaryName = sb.ToString();
			}
			return true;
		}

		private static void ParseJsonEntry<T>(BinaryReader reader, T entry, int startPosition, int size) where T : EntryRef
		{
			_ = reader.BaseStream.Position;
			List<PropertyInfo> props = new List<PropertyInfo>(typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			while ((int)reader.BaseStream.Position - startPosition < size - 1)
			{
				byte dataType = reader.ReadByte();
				if (dataType == 0)
				{
					continue;
				}
				string fieldName = reader.ReadNullTerminatedString();
				PropertyInfo pi = props.Find((PropertyInfo x) => x.Name.ToLower() == fieldName.ToLower());
				if (pi != null)
				{
					if (dataType == 1)
					{
						switch (fieldName.ToLower())
						{
						case "chunks":
							pi.SetValue(entry, reader.ParseEntryList<ChunkRef>(), null);
							break;
						case "bundles":
							pi.SetValue(entry, reader.ParseEntryList<BundleRef>(), null);
							break;
						case "ebx":
							pi.SetValue(entry, reader.ParseEntryList<EbxRef>(), null);
							break;
						case "dbx":
							pi.SetValue(entry, reader.ParseEntryList<DbxRef>(), null);
							break;
						case "res":
							pi.SetValue(entry, reader.ParseEntryList<ResRef>(), null);
							break;
						case "chunkmeta":
							pi.SetValue(entry, reader.ParseEntryList<ChunkMetaRef>(), null);
							break;
						}
					}
					else
					{
						object value = reader.ReadFieldValue(dataType);
						pi.SetValue(entry, value, null);
					}
				}
				else
				{
					reader.ReadFieldValue(dataType, true);
				}
			}
			reader.ReadByte();
		}

		internal static HashedList<T> ParseEntryList<T>(this BinaryReader reader, bool ignore = false) where T : EntryRef, new()
		{
			int startPosition = (int)reader.BaseStream.Position;
			int size = (int)reader.ReadEncodedSize();
			if (ignore)
			{
				reader.BaseStream.Seek(reader.BaseStream.Position + size, SeekOrigin.Begin);
				return null;
			}
			HashedList<T> list = new HashedList<T>();
			while ((int)reader.BaseStream.Position - startPosition < size)
			{
				T entry = new T();
				if (reader.ParseEntry(entry))
				{
					list.Add(entry);
				}
			}
			return list;
		}

		private static object ReadFieldValue(this BinaryReader reader, int dataType, bool ignore = false)
		{
			switch (dataType)
			{
			case 6:
				return reader.ReadByte() == 1;
			case 2:
			case 19:
				return reader.ReadByteArrayField();
			case 8:
				return reader.ReadInt32();
			case 9:
				return reader.ReadInt64();
			case 15:
				return reader.ReadGuidAsString();
			case 16:
				return reader.ReadSha1();
			case 7:
				return reader.ReadStringField();
			case 1:
				return reader.ParseEntryList<EntryRef>(ignore);
			default:
				return null;
			}
		}
	}
}

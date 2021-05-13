using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;

namespace DAI.FrostbiteAssets
{
	public static class FrostbiteAssetFactory
	{
		public const string ASSET_NAMEPSACE = "DAI.FrostbiteAssets.";

		public static object CreateObject(string className, AssetContainer Container, ComplexObject complexValue, ExternalGuid extGuid = null)
		{
			object obj = Assembly.GetAssembly(typeof(FrostbiteAssetFactory)).CreateInstance("DAI.FrostbiteAssets." + className);
			if (obj == null)
			{
				return null;
			}
			if (extGuid != null && typeof(FrostbiteAssetBase).IsAssignableFrom(obj.GetType()))
			{
				((FrostbiteAssetBase)obj).Id = extGuid;
				if (!Container.Objects.ContainsKey(extGuid.FileGuid))
				{
					Container.Objects.Add(extGuid.FileGuid, new Dictionary<Guid, FrostbiteAssetBase>());
				}
				Container.Objects[extGuid.FileGuid].Add(extGuid.InstanceGuid, (FrostbiteAssetBase)obj);
			}
			ParseDynamicObject(obj, className, Container, complexValue);
			return obj;
		}

		internal static object CreateObjectFromGuid(AssetContainer Container, ExternalGuid guidValue)
		{
			if (guidValue.InstanceGuid == Guid.Empty)
			{
				return null;
			}
			if (!Container.Objects.ContainsKey(guidValue.FileGuid))
			{
				Container.Objects.Add(guidValue.FileGuid, new Dictionary<Guid, FrostbiteAssetBase>());
			}
			if (!Container.Objects[guidValue.FileGuid].ContainsKey(guidValue.InstanceGuid))
			{
				EbxBase ebx = EbxBase.FromEbx(Library.GetEbxByGuid(guidValue.FileGuid));
				if (ebx == null)
				{
					return null;
				}
				if ((FrostbiteAssetBase)CreateObject(ebx.Instances[guidValue.InstanceGuid].Descriptor.FieldName, Container, ebx.Instances[guidValue.InstanceGuid], guidValue) == null)
				{
					return null;
				}
			}
			return Container.Objects[guidValue.FileGuid][guidValue.InstanceGuid];
		}

		public static void ParseObject<T>(T obj, AssetContainer Container, ComplexObject complexValue)
		{
			List<PropertyInfo> props = new List<PropertyInfo>(typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			bool missingFields = false;
			foreach (EbxField field in complexValue.Fields)
			{
				if (field.Descriptor.FieldName == "$")
				{
					ComplexObject baseObject = field.ComplexValue;
					ParseDynamicObject(obj, baseObject.Descriptor.FieldName, Container, baseObject);
					continue;
				}
				PropertyInfo pi = props.Find((PropertyInfo x) => x.Name == field.Descriptor.FieldName);
				if (pi == null)
				{
					missingFields = true;
					continue;
				}
				object fieldValue = GetFieldValue(complexValue.Descriptor.FieldName, field, Container, complexValue, pi);
				if (fieldValue != null)
				{
					try
					{
						pi.SetValue(obj, fieldValue, null);
					}
					catch (Exception)
					{
					}
				}
			}
		}

		private static void ParseDynamicObject(object obj, string className, AssetContainer Container, ComplexObject complexValue)
		{
			Type objType = Assembly.GetAssembly(typeof(FrostbiteAssetFactory)).GetType("DAI.FrostbiteAssets." + className);
			if (!(objType == null) && objType.IsAssignableFrom(obj.GetType()))
			{
				try
				{
					typeof(FrostbiteAssetFactory).GetMethod("ParseObject").MakeGenericMethod(objType).Invoke(null, new object[3] { obj, Container, complexValue });
				}
				catch (Exception)
				{
				}
			}
		}

		private static object ParseArrayField(string className, ComplexObject arrayObject, AssetContainer Container, ComplexObject complexValue, PropertyInfo pi)
		{
			if (arrayObject.Fields.Count == 0)
			{
				return null;
			}
			List<object> objects = new List<object>();
			Type arrayType = pi.PropertyType.GetGenericArguments()[0];
			foreach (EbxField field in arrayObject.Fields)
			{
				object obj = GetFieldValue(className, field, Container, field.ComplexValue, pi);
				if (obj != null)
				{
					objects.Add(obj);
				}
			}
			if (objects.Count == 0)
			{
				return null;
			}
			return typeof(FrostbiteAssetFactory).GetMethod("GetArrayFieldValue").MakeGenericMethod(arrayType).Invoke(null, new object[2]
			{
				className,
				objects.ToArray()
			});
		}

		public static List<T> GetArrayFieldValue<T>(string className, object[] objs)
		{
			List<T> list = new List<T>();
			foreach (object obj in objs)
			{
				try
				{
					list.Add((T)obj);
				}
				catch (Exception)
				{
				}
			}
			return list;
		}

		public static ExternalObject<T> CreateComplexExternalGuid<T>(ExternalGuid guid, T obj) where T : FrostbiteAssetBase
		{
			return new ExternalObject<T>(guid, obj, false);
		}

		private static object GetFieldValue(string className, EbxField field, AssetContainer Container, ComplexObject complexValue, PropertyInfo pi)
		{
			switch (field.Descriptor.FieldType)
			{
			case FieldType.DAI_Array:
				return ParseArrayField(className, field.ComplexValue, Container, complexValue, pi);
			case FieldType.DAI_BaseObjectField:
			case FieldType.DAI_LinkObjectField:
			case FieldType.DAI_ChildObjectField:
			case FieldType.DAI_StructField:
				return CreateObject(field.ComplexValue.Descriptor.FieldName, Container, field.ComplexValue);
			case FieldType.DAI_Enum:
				return field.GetEnumIntValue();
			case FieldType.DAI_ExternalID:
			{
				ExternalGuid extGuid = field.GetValueAsGuid();
				if (extGuid.FileGuid == Guid.Empty)
				{
					extGuid.FileGuid = Container.FileGuid;
				}
				pi.GetCustomAttributes(true);
				Type t = pi.PropertyType;
				while (t.GetGenericArguments().Length != 0)
				{
					t = t.GetGenericArguments()[0];
				}
				return typeof(FrostbiteAssetFactory).GetMethod("CreateComplexExternalGuid").MakeGenericMethod(t).Invoke(null, new object[2] { extGuid, null });
			}
			default:
				return field.Value;
			}
		}

		private static string GetFullClassName(string className, ComplexObject obj)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(className);
			while (obj != null && obj.HasField("$") && obj.GetFieldByName("$").ComplexValue != null)
			{
				sb.Append(".");
				sb.Append(obj.GetFieldByName("$").ComplexValue.Descriptor.FieldName);
				obj = obj.GetFieldByName("$").ComplexValue;
			}
			return sb.ToString();
		}
	}
}

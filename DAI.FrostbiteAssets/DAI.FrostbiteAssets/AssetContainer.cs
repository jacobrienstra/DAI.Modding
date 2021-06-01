using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using DAI.AssetLibrary.Assets.Bases;

namespace DAI.FrostbiteAssets
{
	public class AssetContainer
	{
		public Dictionary<Guid, Dictionary<Guid, FrostbiteAssetBase>> Objects { get; private set; }

		public List<FrostbiteAssetBase> UniqueObjects { get; private set; }

		public FrostbiteAssetBase RootObject { get; internal set; }

		public Guid FileGuid { get; set; }

		public AssetContainer()
		{
			RootObject = null;
			Objects = new Dictionary<Guid, Dictionary<Guid, FrostbiteAssetBase>>();
			UniqueObjects = new List<FrostbiteAssetBase>();
		}

		public AssetContainer(EbxBase baseEbx)
			: this()
		{
			FileGuid = baseEbx.FileGuid;
			ParseEbx(baseEbx);
		}

		public void ParseEbx(EbxBase baseEbx)
		{
			if (!Objects.ContainsKey(baseEbx.FileGuid))
			{
				Objects.Add(baseEbx.FileGuid, new Dictionary<Guid, FrostbiteAssetBase>());
			}
			for (int i = 0; i < baseEbx.Instances.Count; i++)
			{
				if (Objects[baseEbx.FileGuid].ContainsKey(baseEbx.Instances.Keys.ElementAt(i)))
				{
					Objects[baseEbx.FileGuid][baseEbx.Instances.Keys.ElementAt(i)].Id = new ExternalGuid(baseEbx.FileGuid, baseEbx.Instances.Keys.ElementAt(i));
					continue;
				}
				Guid id = baseEbx.Instances.Keys.ElementAt(i);
				FrostbiteAssetBase dAIBaseClass = (FrostbiteAssetBase)FrostbiteAssetFactory.CreateObject(baseEbx.Instances[id].Descriptor.FieldName, this, baseEbx.Instances[id], new ExternalGuid(baseEbx.FileGuid, id));
				if (dAIBaseClass != null)
				{
					UniqueObjects.Add(dAIBaseClass);
					if (RootObject == null)
					{
						RootObject = dAIBaseClass;
					}
				}
			}
		}

		public bool IsValid()
		{
			return RootObject != null;
		}

		public EbxBase ToEbxBase()
		{
			EbxBase ebx = new EbxBase();
			ebx.FileGuid = FileGuid;
			CreateDescriptors(ebx);
			return ebx;
		}

		private void CreateDescriptors(EbxBase ebxBase)
		{
			foreach (FrostbiteAssetBase asset in GetOrderedInstances())
			{
				CreateComplexObjectDescriptor(ebxBase, asset, asset.GetType(), ComplexObjectType.Asset);
			}
		}

		private List<FrostbiteAssetBase> GetOrderedInstances()
		{
			List<FrostbiteAssetBase> list = new List<FrostbiteAssetBase>(UniqueObjects);
			list.Sort((FrostbiteAssetBase a, FrostbiteAssetBase b) => a.GetType().Name.CompareTo(b.GetType().Name));
			return list;
		}

		private ComplexObjectDescriptor CreateComplexObjectDescriptor(EbxBase ebx, object cObj, Type t, ComplexObjectType objType)
		{
			if (t == typeof(object) || t == typeof(LinkObject) || t == typeof(ValueType) || t == typeof(FrostbiteAssetBase) || t == typeof(Dummy))
			{
				return null;
			}
			ComplexObjectDescriptor desc = ebx.ComplexDescriptors.Find((ComplexObjectDescriptor x) => x.FieldName == t.Name);
			if (desc != null)
			{
				return desc;
			}
			List<string> newObjects = new List<string>();
			desc = CreateBase(ebx, cObj, t, ComplexObjectType.Asset, ref newObjects);
			CreateFieldDescriptors(ebx, t, cObj, newObjects);
			return desc;
		}

		private ComplexObjectDescriptor CreateBase(EbxBase ebx, object cObj, Type t, ComplexObjectType objType, ref List<string> newObjects)
		{
			if (t == typeof(object) || t == typeof(LinkObject) || t == typeof(ValueType) || t == typeof(FrostbiteAssetBase) || t == typeof(Dummy))
			{
				return null;
			}
			CreateBase(ebx, cObj, t.BaseType, objType, ref newObjects);
			ComplexObjectDescriptor desc = ebx.ComplexDescriptors.Find((ComplexObjectDescriptor x) => x.FieldName == t.Name);
			if (desc != null)
			{
				return desc;
			}
			PropertyInfo[] propDesc = t.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
			desc = new ComplexObjectDescriptor();
			desc.Alignment = GetAlignment(t);
			desc.FieldCount = (byte)propDesc.Length;
			desc.FieldName = t.Name;
			desc.FieldSize = (short)ComputeObjectSize(t);
			desc.FieldType = objType;
			ebx.ComplexDescriptors.Add(desc);
			ebx.AddKeyword(desc.FieldName);
			newObjects.Add(desc.FieldName);
			return desc;
		}

		private void CreateFieldDescriptors(EbxBase ebx, Type t, object cObj, List<string> newObjects)
		{
			if (!newObjects.Contains(t.Name))
			{
				return;
			}
			bool hasBase = false;
			ComplexObjectDescriptor baseDesc = ebx.ComplexDescriptors.Find((ComplexObjectDescriptor x) => x.FieldName == t.BaseType.Name);
			ComplexObjectDescriptor desc = ebx.ComplexDescriptors.Find((ComplexObjectDescriptor x) => x.FieldName == t.Name);
			if (baseDesc != null)
			{
				CreateFieldDescriptors(ebx, t.BaseType, cObj, newObjects);
				hasBase = true;
				FieldDescriptor baseFd = new FieldDescriptor();
				baseFd.FieldName = "$";
				baseFd.PayloadOffset = 8;
				baseFd.FieldType = FieldType.DAI_BaseObjectField;
				baseFd.ComplexReference = (short)ebx.ComplexDescriptors.IndexOf(baseDesc);
				ebx.FieldDescriptors.Add(baseFd);
			}
			desc.FieldStartIndex = ebx.FieldDescriptors.Count;
			if (hasBase)
			{
				desc.FieldStartIndex--;
				desc.FieldCount++;
			}
			ebx.AddKeyword(desc.FieldName);
			PropertyInfo[] properties = t.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
			Dictionary<PropertyInfo, FieldDescriptor> children = new Dictionary<PropertyInfo, FieldDescriptor>();
			PropertyInfo[] array = properties;
			foreach (PropertyInfo pd in array)
			{
				FieldOffsetAttribute att = (FieldOffsetAttribute)pd.GetCustomAttributes(typeof(FieldOffsetAttribute), false)[0];
				FieldDescriptor fd = new FieldDescriptor();
				fd.FieldName = pd.Name;
				fd.FieldType = GetFieldType(pd.PropertyType);
				fd.PayloadOffset = att.Offset;
				fd.SecondaryOffset = att.SecondaryOffset;
				ebx.AddKeyword(pd.Name);
				ebx.FieldDescriptors.Add(fd);
				if (fd.FieldType == FieldType.DAI_Array || fd.FieldType == FieldType.DAI_Enum || fd.FieldType == FieldType.DAI_ExternalID || fd.FieldType == FieldType.DAI_ChildObjectField || fd.FieldType == FieldType.DAI_LinkObjectField || fd.FieldType == FieldType.DAI_StructField)
				{
					children.Add(pd, fd);
				}
			}
			foreach (KeyValuePair<PropertyInfo, FieldDescriptor> pair in children)
			{
				PropertyInfo pd2 = pair.Key;
				ComplexObjectDescriptor childDesc = null;
				switch (GetFieldType(pd2.PropertyType))
				{
				case FieldType.DAI_Array:
					childDesc = (ComplexObjectDescriptor)typeof(AssetContainer).GetMethod("CreateArrayDescriptor", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(pd2.PropertyType.GetGenericArguments()[0]).Invoke(this, new object[3] { pd2, cObj, ebx });
					break;
				case FieldType.DAI_ChildObjectField:
					childDesc = CreateComplexObjectDescriptor(ebx, (cObj == null) ? null : pd2.GetValue(cObj, null), pd2.PropertyType, ComplexObjectType.ChildObject);
					break;
				case FieldType.DAI_LinkObjectField:
					childDesc = CreateComplexObjectDescriptor(ebx, (cObj == null) ? null : pd2.GetValue(cObj, null), pd2.PropertyType, ComplexObjectType.LinkObject);
					break;
				case FieldType.DAI_StructField:
					childDesc = CreateComplexObjectDescriptor(ebx, (cObj == null) ? null : pd2.GetValue(cObj, null), pd2.PropertyType, ComplexObjectType.Struct);
					break;
				case FieldType.DAI_Enum:
					childDesc = CreateEnumDescriptor(pd2.PropertyType, ebx);
					break;
				}
				pair.Value.ComplexReference = (short)Math.Max(0, ebx.ComplexDescriptors.IndexOf(childDesc));
			}
		}

		private ComplexObjectDescriptor CreateArrayDescriptor<T>(PropertyInfo pd, object cObj, EbxBase ebx)
		{
			ComplexObjectDescriptor desc = null;
			FieldType fieldType = GetFieldType(pd.PropertyType.GetGenericArguments()[0]);
			List<T> value = ((cObj == null) ? new List<T>() : ((List<T>)pd.GetValue(cObj, null)));
			int descIndex = 0;
			if (fieldType == FieldType.DAI_ChildObjectField || fieldType == FieldType.DAI_StructField || fieldType == FieldType.DAI_LinkObjectField)
			{
				desc = ebx.ComplexDescriptors.Find((ComplexObjectDescriptor x) => x.FieldName == typeof(T).Name);
				if (desc == null)
				{
					descIndex = ebx.ComplexDescriptors.Count + 1;
				}
				else
				{
					descIndex = ebx.ComplexDescriptors.IndexOf(desc);
				}
			}
			FieldDescriptor memberFd = null;
			ComplexObjectDescriptor arrayDesc = null;
			memberFd = ebx.FieldDescriptors.Find((FieldDescriptor x) => x.FieldName == "member" && x.FieldType == fieldType && x.ComplexReference == descIndex);
			if (memberFd != null)
			{
				arrayDesc = ebx.ComplexDescriptors.Find((ComplexObjectDescriptor x) => x.FieldType == ComplexObjectType.Array && x.FieldStartIndex == ebx.FieldDescriptors.IndexOf(memberFd));
				if (arrayDesc != null)
				{
					return arrayDesc;
				}
			}
			arrayDesc = new ComplexObjectDescriptor();
			arrayDesc.FieldName = "array";
			arrayDesc.Alignment = 4;
			arrayDesc.FieldCount = 1;
			arrayDesc.FieldSize = 4;
			arrayDesc.FieldType = ComplexObjectType.Array;
			arrayDesc.FieldStartIndex = ebx.FieldDescriptors.Count;
			ebx.ComplexDescriptors.Add(arrayDesc);
			memberFd = new FieldDescriptor();
			memberFd.FieldName = "member";
			memberFd.FieldType = fieldType;
			ebx.FieldDescriptors.Add(memberFd);
			if (desc == null && (fieldType == FieldType.DAI_ChildObjectField || fieldType == FieldType.DAI_StructField || fieldType == FieldType.DAI_LinkObjectField))
			{
				if (fieldType == FieldType.DAI_ChildObjectField || fieldType == FieldType.DAI_StructField || fieldType == FieldType.DAI_LinkObjectField)
				{
					ComplexObjectType cObjType = ComplexObjectType.ChildObject;
					if (fieldType == FieldType.DAI_StructField)
					{
						cObjType = ComplexObjectType.Struct;
					}
					if (fieldType == FieldType.DAI_LinkObjectField)
					{
						cObjType = ComplexObjectType.LinkObject;
					}
					desc = ((value.Count != 0) ? CreateComplexObjectDescriptor(ebx, value[0], typeof(T), cObjType) : CreateComplexObjectDescriptor(ebx, null, typeof(T), cObjType));
				}
				else if (fieldType == FieldType.DAI_Enum)
				{
					desc = CreateEnumDescriptor(typeof(T), ebx);
				}
				descIndex = Math.Max(0, ebx.ComplexDescriptors.IndexOf(desc));
			}
			memberFd.ComplexReference = (short)descIndex;
			return arrayDesc;
		}

		private ComplexObjectDescriptor CreateEnumDescriptor(Type enumType, EbxBase ebx)
		{
			ComplexObjectDescriptor enumDesc = ebx.ComplexDescriptors.Find((ComplexObjectDescriptor x) => x.FieldType == ComplexObjectType.Enum && x.FieldName == enumType.Name);
			if (enumDesc == null)
			{
				string[] names = Enum.GetNames(enumType);
				enumDesc = new ComplexObjectDescriptor();
				enumDesc.FieldName = enumType.Name;
				enumDesc.FieldCount = (byte)names.Length;
				enumDesc.FieldSize = 4;
				enumDesc.Alignment = 4;
				enumDesc.FieldType = ComplexObjectType.Enum;
				enumDesc.FieldStartIndex = ebx.FieldDescriptors.Count;
				string[] array = names;
				foreach (string name in array)
				{
					FieldDescriptor valueFd = new FieldDescriptor();
					valueFd.FieldName = name;
					ebx.FieldDescriptors.Add(valueFd);
				}
				ebx.ComplexDescriptors.Add(enumDesc);
			}
			return enumDesc;
		}

		private FieldType GetFieldType(Type t)
		{
			if (t == typeof(bool))
			{
				return FieldType.DAI_Bool;
			}
			if (t == typeof(byte))
			{
				return FieldType.DAI_UByte;
			}
			if (t == typeof(sbyte))
			{
				return FieldType.DAI_Byte;
			}
			if (t == typeof(short))
			{
				return FieldType.DAI_Short;
			}
			if (t == typeof(ushort))
			{
				return FieldType.DAI_UShort;
			}
			if (t == typeof(int))
			{
				return FieldType.DAI_Int;
			}
			if (t == typeof(uint))
			{
				return FieldType.DAI_UInt;
			}
			if (t == typeof(float))
			{
				return FieldType.DAI_Single;
			}
			if (t == typeof(long))
			{
				return FieldType.DAI_Long;
			}
			if (t == typeof(ulong))
			{
				return FieldType.DAI_ULong;
			}
			if (t == typeof(double))
			{
				return FieldType.DAI_Double;
			}
			if (t == typeof(Guid))
			{
				return FieldType.DAI_Guid;
			}
			if (t == typeof(string))
			{
				return FieldType.DAI_String;
			}
			if (t.IsEnum)
			{
				return FieldType.DAI_Enum;
			}
			if (t.IsValueType)
			{
				return FieldType.DAI_StructField;
			}
			if (t.Name.StartsWith("List"))
			{
				return FieldType.DAI_Array;
			}
			if (t.Name.StartsWith("ExternalObject"))
			{
				return FieldType.DAI_ExternalID;
			}
			if (t.BaseType == typeof(LinkObject))
			{
				return FieldType.DAI_LinkObjectField;
			}
			return FieldType.DAI_ChildObjectField;
		}

		private int ComputeObjectSize(Type t)
		{
			if (t == typeof(FrostbiteAssetBase))
			{
				return 0;
			}
			if (t == typeof(object))
			{
				return 0;
			}
			if (t == typeof(ValueType))
			{
				return 0;
			}
			if (t == typeof(DataContainer))
			{
				return 8;
			}
			if (t == typeof(LinkObject))
			{
				return 0;
			}
			int size = 0;
			int align = GetAlignment(t);
			size += ComputeObjectSize(t.BaseType);
			PropertyInfo[] properties = t.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
			_ = t.Name;
			PropertyInfo[] array = properties;
			foreach (PropertyInfo p in array)
			{
				if (!(p.PropertyType == typeof(ExternalGuid)))
				{
					switch (GetFieldType(p.PropertyType))
					{
					case FieldType.DAI_Bool:
					case FieldType.DAI_Byte:
					case FieldType.DAI_UByte:
						size++;
						break;
					case FieldType.DAI_UShort:
					case FieldType.DAI_Short:
						size += 2;
						break;
					case FieldType.DAI_ExternalID:
					case FieldType.DAI_Array:
					case FieldType.DAI_String:
					case FieldType.DAI_Enum:
					case FieldType.DAI_Int:
					case FieldType.DAI_UInt:
					case FieldType.DAI_Single:
						size += 4;
						break;
					case FieldType.DAI_Long:
					case FieldType.DAI_ULong:
					case FieldType.DAI_Double:
						size += 8;
						break;
					case FieldType.DAI_BaseObjectField:
					case FieldType.DAI_LinkObjectField:
					case FieldType.DAI_ChildObjectField:
					case FieldType.DAI_StructField:
						size += ComputeObjectSize(p.PropertyType);
						break;
					case FieldType.DAI_Guid:
						size += 16;
						break;
					}
				}
			}
			return align * (int)Math.Ceiling((float)size * 1f / (float)align);
		}

		private byte GetAlignment(Type t)
		{
			return ((DescriptorAlignmentAttribute)TypeDescriptor.GetAttributes(t)[typeof(DescriptorAlignmentAttribute)]).Alignment;
		}
	}
}

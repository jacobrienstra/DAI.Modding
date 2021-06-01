using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;

using DAI.AssetLibrary.Utilities.Extensions;
// TODO: Reconcile with OG manager
namespace DAI.Mod {
    public class ModJob {
        public string Name { get; set; }

        public string Xml { get; set; }

        public string Script { get; set; }

        public List<byte[]> Data { get; set; }

        public ModMetaData Meta { get; set; }

        public ModScript ScriptObject;

        public Dictionary<string, object> ConfigValues;

        public string FileName { get; set; }

        public ModJob(string InName, string InXml, string InScript) {
            Name = InName;
            Script = InScript;
            Xml = InXml;
            Data = new List<byte[]>();
        }

        public ModJob() {
            Data = new List<byte[]>();
            Meta = new ModMetaData();
        }

        public static ModJob CreateFromFile(string InPath) {
            ModJob modJob = new ModJob();
            using (FileStream fs = new FileStream(InPath, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader binaryReader = new BinaryReader(fs)) {
                    if (binaryReader.ReadInt32() != 1296646468 || binaryReader.ReadInt32() != 844514383) {
                        return null;
                    }
                    binaryReader.ReadInt32();
                    modJob.Name = binaryReader.ReadNullTerminatedString();
                    modJob.Xml = binaryReader.ReadNullTerminatedString();
                    modJob.Script = binaryReader.ReadNullTerminatedString();
                    modJob.ScriptObject = Scripting.GetModScriptObject(modJob.Script);

                    int num1 = binaryReader.ReadInt32();
                    for (int i = 0; i < num1; i++) {
                        int num2 = binaryReader.ReadInt32();
                        byte[] numArray = new byte[num2];
                        binaryReader.BaseStream.Read(numArray, 0, num2);
                        modJob.Data.Add(numArray);
                    }
                }
            }
            modJob.MakeMeta();
            return modJob;
        }

        public void MakeMeta() {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(Xml);
            foreach (XmlNode childNode in xmlDocument.ChildNodes[0].ChildNodes) {
                switch (childNode.Name) {
                    case "details":
                        foreach (XmlNode xmlNodes in childNode.ChildNodes) {
                            switch (xmlNodes.Name) {
                                case "name":
                                    Meta.Details.Name = HttpUtility.HtmlDecode(xmlNodes.InnerText);
                                    break;
                                case "version":
                                    Meta.Details.Version = HttpUtility.HtmlDecode(xmlNodes.InnerText);
                                    break;
                                case "author":
                                    Meta.Details.Author = HttpUtility.HtmlDecode(xmlNodes.InnerText);
                                    break;
                                case "description":
                                    Meta.Details.Description = HttpUtility.HtmlDecode(xmlNodes.InnerText);
                                    break;
                            }
                        }
                        break;
                    case "resources":
                        foreach (XmlNode xmlNodes in childNode.ChildNodes) {
                            if (!(xmlNodes.Name != "resource")) {
                                ModResourceEntry modResourceEntry = null;
                                switch (xmlNodes.Attributes["type"].Value) {
                                    case "chunk":
                                        modResourceEntry = new ChunkModResourceEntry(xmlNodes.Attributes);
                                        break;
                                    case "res":
                                        modResourceEntry = new ResModResourceEntry(xmlNodes.Attributes);
                                        break;
                                    case "ebx":
                                        modResourceEntry = new EbxModResourceEntry(xmlNodes.Attributes);
                                        break;
                                }
                                Meta.Resources.Add(modResourceEntry);
                            }
                        }
                        break;
                    case "bundles":
                        foreach (XmlNode xmlNodes2 in childNode.ChildNodes) {
                            if (xmlNodes2.Name != "bundle") {
                                continue;
                            }
                            ModBundle modBundle = new ModBundle();
                            foreach (XmlAttribute xmlAttribute in xmlNodes2.Attributes) {
                                string attributeName = xmlAttribute.Name;
                                if (attributeName != null) {
                                    switch (attributeName.ToLower()) {
                                        case "name":
                                            modBundle.Name = xmlAttribute.Value;
                                            break;
                                        case "filename":
                                            modBundle.TocFilename = xmlAttribute.Value;
                                            break;
                                        case "magicsalt":
                                            modBundle.MagicSalt = Convert.ToInt32(xmlAttribute.Value);
                                            break;
                                        case "alignmembers":
                                            modBundle.AlignMembers = Convert.ToByte(xmlAttribute.Value);
                                            break;
                                        case "ridsupport":
                                            modBundle.RidSupport = Convert.ToByte(xmlAttribute.Value);
                                            break;
                                        case "storecompressedsizes":
                                            modBundle.StoreCompressedSizes = Convert.ToByte(xmlAttribute.Value);
                                            break;
                                        case "action":
                                            modBundle.Action = xmlAttribute.Value;
                                            break;
                                    }
                                }
                            }
                            foreach (XmlNode item in xmlNodes2.ChildNodes[0]) {
                                ModBundleEntry modBundleEntry = new ModBundleEntry();
                                foreach (XmlAttribute attribute1 in item.Attributes) {
                                    string name4 = attribute1.Name;
                                    if (name4 != null && name4 == "id") {
                                        modBundleEntry.ResourceId = Convert.ToInt32(attribute1.Value);
                                    }
                                }
                                modBundle.Entries.Add(modBundleEntry);
                            }
                            Meta.Bundles.Add(modBundle);
                        }
                        break;
                }
            }
            foreach (XmlAttribute xmlAttribute2 in xmlDocument.ChildNodes[0].Attributes) {
                switch (xmlAttribute2.Name) {
                    case "version":
                        Meta.FormatVersion = Convert.ToByte(xmlAttribute2.Value);
                        break;
                    case "id":
                        Meta.ID = xmlAttribute2.Value;
                        break;
                    case "minPatchVersion":
                        Meta.MinPatchVersion = Convert.ToByte(xmlAttribute2.Value);
                        break;
                    case "toolSet":
                        Meta.ToolSetVersion = Convert.ToInt32(xmlAttribute2.Value);
                        break;
                }
            }
        }

        public string MakeXml() {
            using (StringWriter sw = new StringWriter()) {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.Encoding = Encoding.UTF8;
                settings.OmitXmlDeclaration = true;
                using (XmlWriter writer = XmlWriter.Create(sw, settings)) {
                    writer.WriteStartElement("daimod");
                    writer.WriteAttributeString("version", Meta.FormatVersion.ToString());
                    writer.WriteAttributeString("id", Meta.ID);
                    writer.WriteAttributeString("minPatchVersion", Meta.MinPatchVersion.ToString());
                    writer.WriteAttributeString("toolset", Meta.ToolSetVersion.ToString());
                    writer.WriteStartElement("details");
                    writer.WriteStartElement("name");
                    writer.WriteString(HttpUtility.HtmlEncode(Meta.Details.Name));
                    writer.WriteEndElement();
                    writer.WriteStartElement("version");
                    writer.WriteString(HttpUtility.HtmlEncode(Meta.Details.Version));
                    writer.WriteEndElement();
                    writer.WriteStartElement("author");
                    writer.WriteString(HttpUtility.HtmlEncode(Meta.Details.Author));
                    writer.WriteEndElement();
                    writer.WriteStartElement("description");
                    writer.WriteString(HttpUtility.HtmlEncode(Meta.Details.Description));
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteStartElement("requirements");
                    writer.WriteEndElement();
                    writer.WriteStartElement("resources");
                    foreach (ModResourceEntry resource in Meta.Resources) {
                        writer.WriteStartElement("resource");
                        writer.WriteAttributeString("name", resource.Name);
                        writer.WriteAttributeString("type", resource.Type);
                        writer.WriteAttributeString("action", resource.Action);
                        if (resource.Action == "add" || resource.Action == "modify") {
                            switch (resource.Type) {
                                case "chunk": {
                                        ChunkModResourceEntry chunkEntry = (ChunkModResourceEntry)resource;
                                        writer.WriteAttributeString("chunkH32", chunkEntry.ChunkH32.ToString());
                                        writer.WriteAttributeString("meta", chunkEntry.Meta);
                                        writer.WriteAttributeString("rangeStart", chunkEntry.RangeStart.ToString());
                                        writer.WriteAttributeString("rangeEnd", chunkEntry.RangeEnd.ToString());
                                        writer.WriteAttributeString("logicalOffset", chunkEntry.LogicalOffset.ToString());
                                        writer.WriteAttributeString("logicalSize", chunkEntry.LogicalSize.ToString());
                                        break;
                                    }
                                case "res": {
                                        ResModResourceEntry resEntry = (ResModResourceEntry)resource;
                                        writer.WriteAttributeString("resType", resEntry.ResType.ToString());
                                        writer.WriteAttributeString("resRid", resEntry.ResRid.ToString());
                                        writer.WriteAttributeString("meta", resEntry.Meta);
                                        writer.WriteAttributeString("originalSize", resource.OriginalSize.ToString());
                                        break;
                                    }
                                case "ebx":
                                    writer.WriteAttributeString("originalSize", resource.OriginalSize.ToString());
                                    break;
                            }
                            writer.WriteAttributeString("size", resource.Size.ToString());
                            writer.WriteAttributeString("patch", resource.PatchType.ToString());
                            if (resource.Action != "modify") {
                                writer.WriteAttributeString("sha1", resource.OriginalSha1.ToString());
                            } else {
                                writer.WriteAttributeString("originalSha1", resource.OriginalSha1.ToString());
                                writer.WriteAttributeString("sha1", resource.NewSha1.ToString());
                            }
                            if (resource.PatchType == 2) {
                                writer.WriteAttributeString("deltaSha1", resource.DeltaSha1.ToString());
                                writer.WriteAttributeString("baseSha1", resource.BaseSha1.ToString());
                            }
                            writer.WriteAttributeString("resourceId", resource.ResourceID.ToString());
                        } else {
                            writer.WriteAttributeString("originalSha1", resource.OriginalSha1.ToString());
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("bundles");
                    foreach (ModBundle bundle in Meta.Bundles) {
                        writer.WriteStartElement("bundle");
                        writer.WriteAttributeString("name", bundle.Name);
                        writer.WriteAttributeString("action", bundle.Action);
                        if (bundle.Action == "add") {
                            writer.WriteAttributeString("filename", bundle.TocFilename);
                            writer.WriteAttributeString("magicSalt", bundle.MagicSalt.ToString());
                            writer.WriteAttributeString("alignMembers", bundle.AlignMembers.ToString());
                            writer.WriteAttributeString("ridSupport", bundle.RidSupport.ToString());
                            writer.WriteAttributeString("storeCompressedSizes", bundle.StoreCompressedSizes.ToString());
                        }
                        writer.WriteStartElement("entries");
                        foreach (ModBundleEntry entry in bundle.Entries) {
                            writer.WriteStartElement("entry");
                            writer.WriteAttributeString("id", entry.ResourceId.ToString());
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                return sw.ToString();
            }
        }

        public void Save(string OutPath) {
            Xml = MakeXml();
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(OutPath, FileMode.Create));
            binaryWriter.Write(1296646468);
            binaryWriter.Write(844514383);
            binaryWriter.Write(1);
            binaryWriter.WriteNullTerminatedString(Name);
            binaryWriter.WriteNullTerminatedString(Xml);
            binaryWriter.WriteNullTerminatedString(Script);
            binaryWriter.Write(Data.Count);
            foreach (byte[] datum in Data) {
                if (datum == null) {
                    binaryWriter.Write(0);
                    continue;
                }
                binaryWriter.Write(datum.Length);
                binaryWriter.Write(datum);
            }
            binaryWriter.Close();
        }

        public void ResetData() {
            Data.Clear();
        }
    }
}

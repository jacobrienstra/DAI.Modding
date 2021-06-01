using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;
using System.Windows.Controls;

using Microsoft.CSharp;

namespace DAI.Mod {
    public static class Scripting {
        public static ModJob CurrentMod;

        public static TextBox ScriptingTextBox;
        //public static ProgressWindow ProgressWindow;

        public static Assembly CompileCode(string InCode) {
            string ModCode = InCode.Replace("namespace DAIMod", "namespace DAI.Mod");
            CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();
            CompilerParameters compilerParameter = new CompilerParameters {
                GenerateExecutable = false,
                GenerateInMemory = true
            };
            compilerParameter.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            compilerParameter.ReferencedAssemblies.Add("System.dll");
            compilerParameter.ReferencedAssemblies.Add("System.Core.dll");
            compilerParameter.ReferencedAssemblies.Add("System.Data.Linq.dll");
            CompilerResults compilerResults = null;
            try {
                compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameter, ModCode);
            } catch (Exception ex) {
                throw new Exception("Exception caught: " + ex.Message);
            }
            if (compilerResults.Errors.HasErrors) {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Line: " + compilerResults.Errors[0].Line + " Column: " + compilerResults.Errors[0].Column + "\n");
                stringBuilder.Append("(" + compilerResults.Errors[0].ErrorNumber + ")\n");
                stringBuilder.Append(compilerResults.Errors[0].ErrorText);
                throw new Exception(stringBuilder.ToString());
            }
            return compilerResults.CompiledAssembly;
        }

        public static ModScript GetModScriptObject(string InCode) {
            if (InCode == "") {
                return null;
            }
            Assembly assembly = null;
            try {
                assembly = CompileCode(InCode);
            } catch (Exception ex) {
                throw ex;
            }
            foreach (Type item in from t in assembly.GetExportedTypes()
                                  where t.GetInterfaces().Any()
                                  select t) {
                ConstructorInfo constructor = item.GetConstructor(Type.EmptyTypes);
                if (constructor != null && constructor.IsPublic) {
                    ModScript modScript = constructor.Invoke(null) as ModScript;
                    if (modScript != null) {
                        return modScript;
                    }
                }
            }
            return null;
        }

        public static void LogLn(string InStr) {
            if (CurrentMod != null) {
                ScriptingTextBox.Text += "[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "] " + InStr + "\n";
                ScriptingTextBox.ScrollToEnd();
            }
        }

        public static object GetConfigParam(string InParamName) {
            if (CurrentMod == null || !CurrentMod.ConfigValues.ContainsKey(InParamName)) {
                return null;
            }
            return CurrentMod.ConfigValues[InParamName];
        }

        public static byte[] GetResourceData(int InIndex) {
            if (CurrentMod == null) {
                return null;
            }
            if (InIndex < CurrentMod.Data.Count) {
                return Utils.DecompressData(CurrentMod.Data[InIndex]);
            }
            LogLn("Data index is out of range");
            return null;
        }

        public static bool ChangeResourceId(int InResourceIndex, int InNewResourceId) {
            if (CurrentMod == null) {
                return false;
            }
            if (InResourceIndex >= CurrentMod.Meta.Resources.Count) {
                LogLn("Resource index is out of range");
                return false;
            }
            CurrentMod.Meta.Resources[InResourceIndex].ResourceID = InNewResourceId;
            ModResourceEntry modResourceEntry = CurrentMod.Meta.Resources[InResourceIndex];
            Sha1 sha = Utils.CalculateSha1(CurrentMod.Data[modResourceEntry.ResourceID]);
            byte[] array = Utils.DecompressData(CurrentMod.Data[modResourceEntry.ResourceID]);
            if (modResourceEntry.Action == "modify") {
                modResourceEntry.NewSha1 = sha;
            } else if (modResourceEntry.Action == "add") {
                modResourceEntry.OriginalSha1 = sha;
            }
            modResourceEntry.Size = CurrentMod.Data[modResourceEntry.ResourceID].Length;
            modResourceEntry.OriginalSize = array.Length;
            modResourceEntry.LogicalOffset = array.Length & -16777216;
            modResourceEntry.LogicalSize = array.Length & 0xFFFFFF;
            if (modResourceEntry.RangeStart != 0 || modResourceEntry.RangeEnd != 0) {
                modResourceEntry.RangeStart = 0;
                modResourceEntry.RangeEnd = CurrentMod.Data[modResourceEntry.ResourceID].Length;
            }
            LogLn("ChangeResourceId called (InResourceIndex=\"" + InResourceIndex + "\", InNewResourceId=" + InNewResourceId + ")");
            return true;
        }

        public static bool ChangeResourceId(string InResourceName, int InNewResourceId) {
            if (CurrentMod == null) {
                return false;
            }
            ModResourceEntry modResourceEntry = CurrentMod.Meta.Resources.Find((ModResourceEntry A) => InResourceName.ToLower() == A.Name.ToLower());
            if (modResourceEntry == null) {
                LogLn("Unable to find resource with name " + InResourceName);
                return false;
            }
            modResourceEntry.ResourceID = InNewResourceId;
            Sha1 sha = Utils.CalculateSha1(CurrentMod.Data[modResourceEntry.ResourceID]);
            byte[] array = Utils.DecompressData(CurrentMod.Data[modResourceEntry.ResourceID]);
            if (modResourceEntry.Action == "modify") {
                modResourceEntry.NewSha1 = sha;
            } else if (modResourceEntry.Action == "add") {
                modResourceEntry.OriginalSha1 = sha;
            }
            modResourceEntry.Size = CurrentMod.Data[modResourceEntry.ResourceID].Length;
            modResourceEntry.OriginalSize = array.Length;
            modResourceEntry.LogicalOffset = array.Length & -16777216;
            modResourceEntry.LogicalSize = array.Length & 0xFFFFFF;
            if (modResourceEntry.RangeStart != 0 || modResourceEntry.RangeEnd != 0) {
                modResourceEntry.RangeStart = 0;
                modResourceEntry.RangeEnd = CurrentMod.Data[modResourceEntry.ResourceID].Length;
            }
            LogLn("ChangeResourceId called (InResourceName=\"" + InResourceName + "\", InNewResourceId=" + InNewResourceId + ")");
            return true;
        }

        public static void SetResourceEnabled(int InResourceIndex, bool InNewEnable) {
            if (CurrentMod != null) {
                if (InResourceIndex >= CurrentMod.Meta.Resources.Count) {
                    LogLn("Resource index is out of range");
                    return;
                }
                CurrentMod.Meta.Resources[InResourceIndex].IsEnabled = InNewEnable;
                LogLn("SetResourceEnabled called (InResourceIndex=\"" + InResourceIndex + "\", InNewEnable=" + InNewEnable + ")");
            }
        }

        public static void SetResourceEnabled(string InResourceName, bool InNewEnable) {
            if (CurrentMod != null) {
                ModResourceEntry modResourceEntry = CurrentMod.Meta.Resources.Find((ModResourceEntry A) => InResourceName.ToLower() == A.Name.ToLower());
                if (modResourceEntry == null) {
                    LogLn("Unable to find resource with name " + InResourceName);
                    return;
                }
                modResourceEntry.IsEnabled = InNewEnable;
                LogLn("SetResourceEnabled called (InResourceName=\"" + InResourceName + "\", InNewEnable=" + InNewEnable + ")");
            }
        }

        public static void SetResourceData(int InIndex, byte[] InData) {
            if (CurrentMod == null) {
                return;
            }
            if (InIndex >= CurrentMod.Data.Count) {
                LogLn("Data index is out of range");
                return;
            }
            byte[] array = Utils.CompressData(InData);
            CurrentMod.Data[InIndex] = array;
            Sha1 sha = Utils.CalculateSha1(array);
            foreach (ModResourceEntry resource in CurrentMod.Meta.Resources) {
                if (resource.ResourceID == InIndex) {
                    if (resource.Action == "modify") {
                        resource.NewSha1 = sha;
                    } else if (resource.Action == "add") {
                        resource.OriginalSha1 = sha;
                    }
                    resource.Size = array.Length;
                    resource.OriginalSize = InData.Length;
                    resource.LogicalOffset = InData.Length & -16777216;
                    resource.LogicalSize = InData.Length & 0xFFFFFF;
                    if (resource.RangeStart != 0 || resource.RangeEnd != 0) {
                        resource.RangeStart = 0;
                        resource.RangeEnd = array.Length;
                    }
                }
            }
            LogLn("SetResourceData called (InIndex = " + InIndex + ", InData = " + InData.Length + " bytes)");
            }
        }
    }
}

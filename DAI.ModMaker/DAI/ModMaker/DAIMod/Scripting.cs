using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Controls;

using Microsoft.CSharp;

namespace DAI.ModMaker.DAIMod
{
    public static class Scripting
    {
        public static ModJob CurrentMod;

        public static TextBox ScriptLogTextBox;

        public static Dictionary<string, object> ConfigValues;

        public static bool ChangeResourceId(int InResourceIndex, int InNewResourceId)
        {
            if (CurrentMod == null)
            {
                return false;
            }
            if (InResourceIndex >= CurrentMod.Meta.Resources.Count)
            {
                LogLn("Resource index is out of range");
                return false;
            }
            LogLn("ChangeResourceId called (InResourceIndex=\"" + InResourceIndex + "\", InNewResourceId=" + InNewResourceId + ")");
            return true;
        }

        public static bool ChangeResourceId(string InResourceName, int InNewResourceId)
        {
            if (CurrentMod == null)
            {
                return false;
            }
            if (CurrentMod.Meta.Resources.Find((ModResourceEntry A) => InResourceName.ToLower() == A.Name.ToLower()) == null)
            {
                LogLn("Unable to find resource with name " + InResourceName);
                return false;
            }
            LogLn("ChangeResourceId called (InResourceName=\"" + InResourceName + "\", InNewResourceId=" + InNewResourceId + ")");
            return true;
        }

        public static Assembly CompileCode(string InCode)
        {
            string ModCode = InCode.Replace("namespace DAIMod", "namespace DAI.ModMaker.DAIMod");
            CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();
            CompilerParameters compilerParameter = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = true
            };
            compilerParameter.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            compilerParameter.ReferencedAssemblies.Add("System.dll");
            compilerParameter.ReferencedAssemblies.Add("System.Core.dll");
            compilerParameter.ReferencedAssemblies.Add("System.Data.Linq.dll");
            CompilerResults compilerResult = null;
            try
            {
                string[] inCode = new string[1] { ModCode };
                compilerResult = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameter, inCode);
            }
            catch (Exception exception)
            {
                throw new Exception("Exception caught: " + exception.Message);
            }
            if (compilerResult.Errors.HasErrors)
            {
                StringBuilder stringBuilder = new StringBuilder();
                object[] line = new object[5]
                {
                    "Line: ",
                    compilerResult.Errors[0].Line,
                    " Column: ",
                    compilerResult.Errors[0].Column,
                    " "
                };
                stringBuilder.Append(string.Concat(line));
                stringBuilder.Append("(" + compilerResult.Errors[0].ErrorNumber + ") ");
                stringBuilder.Append(compilerResult.Errors[0].ErrorText);
                throw new Exception(stringBuilder.ToString());
            }
            return compilerResult.CompiledAssembly;
        }

        public static object GetConfigParam(string InParamName)
        {
            if (CurrentMod == null || !ConfigValues.ContainsKey(InParamName))
            {
                return null;
            }
            return ConfigValues[InParamName];
        }

        public static ModScript GetModScriptObject(string InCode)
        {
            Assembly assembly = null;
            if (InCode == "")
            {
                return null;
            }
            try
            {
                assembly = CompileCode(InCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Type[] exportedTypes = assembly.GetExportedTypes();
            foreach (Type type in exportedTypes)
            {
                Type[] interfaces = type.GetInterfaces();
                for (int j = 0; j < interfaces.Length; j++)
                {
                    _ = interfaces[j];
                    ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
                    if (constructor != null && constructor.IsPublic)
                    {
                        ModScript modScript = constructor.Invoke(null) as ModScript;
                        if (modScript != null)
                        {
                            return modScript;
                        }
                    }
                }
            }
            return null;
        }

        public static byte[] GetResourceData(int InIndex)
        {
            if (CurrentMod == null)
            {
                return null;
            }
            if (InIndex >= CurrentMod.Data.Count)
            {
                LogLn("Data index is out of range");
                return null;
            }
            return DAI.AssetLibrary.Utilities.Utilities.DecompressData(CurrentMod.Data[InIndex], -1L);
        }

        public static void LogLn(string InStr)
        {
            if (CurrentMod != null)
            {
                TextBox scriptLogTextBox = ScriptLogTextBox;
                string text = scriptLogTextBox.Text;
                string[] shortDateString = new string[8] { text, "[", null, null, null, null, null, null };
                shortDateString[2] = DateTime.Now.ToShortDateString();
                shortDateString[3] = " ";
                shortDateString[4] = DateTime.Now.ToShortTimeString();
                shortDateString[5] = "] ";
                shortDateString[6] = InStr;
                shortDateString[7] = "\n";
                scriptLogTextBox.Text = string.Concat(shortDateString);
                ScriptLogTextBox.ScrollToEnd();
            }
        }

        public static void SetResourceData(int InIndex, byte[] InData)
        {
            if (CurrentMod != null)
            {
                if (InIndex >= CurrentMod.Data.Count)
                {
                    LogLn("Data index is out of range");
                    return;
                }
                LogLn("SetResourceData called (InIndex = " + InIndex + ", InData = " + InData.Length + " bytes)");
            }
        }

        public static void SetResourceEnabled(int InResourceIndex, bool InNewEnable)
        {
            if (CurrentMod != null)
            {
                if (InResourceIndex >= CurrentMod.Meta.Resources.Count)
                {
                    LogLn("Resource index is out of range");
                    return;
                }
                LogLn("SetResourceEnabled called (InResourceIndex=\"" + InResourceIndex + "\", InNewEnable=" + InNewEnable + ")");
            }
        }

        public static void SetResourceEnabled(string InResourceName, bool InNewEnable)
        {
            if (CurrentMod != null)
            {
                if (CurrentMod.Meta.Resources.Find((ModResourceEntry A) => InResourceName.ToLower() == A.Name.ToLower()) == null)
                {
                    LogLn("Unable to find resource with name " + InResourceName);
                    return;
                }
                LogLn("SetResourceEnabled called (InResourceName=\"" + InResourceName + "\", InNewEnable=" + InNewEnable + ")");
            }
        }
    }
}

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;
using DAI.ModMaker.Properties;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;

namespace DAI.ModMaker.Utilities
{
    public static class Utilities
    {
        public const string EmptySha1 = "00000000000000000000";

        public static T GetNativeObject<T>(EbxRef InAsset) where T : FrostbiteAssetBase
        {
            return (T)EbxBase.FromEbx(InAsset).GetContainer().RootObject;
        }

        public static List<Inline> ConvertStringToInlines(string TalkString, string Device = "PC")
        {
            List<Inline> inlines = new List<Inline>();
            TalkString = TalkString.Replace("<i>", "{i}").Replace("</i>", "{/i}");
            TalkString = TalkString.Replace("<b>", "{b}").Replace("</b>", "{/b}");
            TalkString = TalkString.Replace("<br>", "{linebreak}");
            TalkString = TalkString.Replace("<font>", "{font}").Replace("<font", "{font").Replace("\">", "\"}")
                .Replace("</font>", "{/font}");
            int length = 0;
            int num = TalkString.IndexOf('{', 0);
            int num2 = TalkString.IndexOf('}', 0);
            StringBuilder stringBuilder1 = new StringBuilder();
            Run run;
            if (num != -1)
            {
                while (length < TalkString.Length)
                {
                    if (num != -1 && num2 != -1)
                    {
                        for (; length < num; length++)
                        {
                            stringBuilder1.Append(TalkString[length]);
                        }
                    }
                    string str = "";
                    if (num == -1 || num2 == -1)
                    {
                        for (; length < TalkString.Length; length++)
                        {
                            stringBuilder1.Append(TalkString[length]);
                        }
                        run = new Run(stringBuilder1.ToString())
                        {
                            Foreground = new SolidColorBrush(Colors.White)
                        };
                        inlines.Add(run);
                        return inlines;
                    }
                    str = TalkString.Substring(num, num2 - num + 1);
                    length += str.Length;
                    if (str == "{i}" || str == "{b}")
                    {
                        Run run2 = new Run(stringBuilder1.ToString())
                        {
                            Foreground = new SolidColorBrush(Colors.White)
                        };
                        inlines.Add(run2);
                        stringBuilder1.Clear();
                        num = TalkString.IndexOf((str == "{i}") ? "{/i}" : "{/b}", num + 3);
                        if (num == -1)
                        {
                            num = TalkString.Length;
                        }
                        for (; length < num; length++)
                        {
                            stringBuilder1.Append(TalkString[length]);
                        }
                        length += 4;
                        if (str == "{i}")
                        {
                            Run run3 = new Run(stringBuilder1.ToString())
                            {
                                Foreground = new SolidColorBrush(Colors.White)
                            };
                            inlines.Add(new Italic(run3));
                        }
                        else if (str == "{b}")
                        {
                            Run run4 = new Run(stringBuilder1.ToString())
                            {
                                Foreground = new SolidColorBrush(Colors.White)
                            };
                            inlines.Add(new Bold(run4));
                        }
                        stringBuilder1.Clear();
                    }
                    else if (str.Contains("font"))
                    {
                        string str2 = "#FFFFFF";
                        if (str.Contains("CUSTOM"))
                        {
                            length += 2;
                        }
                        else
                        {
                            int num3 = str.IndexOf("=");
                            if (num3 != -1)
                            {
                                num3 += 2;
                                string str5 = str.Substring(num3, str.IndexOf("\"", num3) - num3);
                                if (!str5.Contains("CUSTOM"))
                                {
                                    str2 = str5;
                                }
                            }
                        }
                        Run run5 = new Run(stringBuilder1.ToString())
                        {
                            Foreground = new SolidColorBrush(Colors.White)
                        };
                        inlines.Add(run5);
                        stringBuilder1.Clear();
                        num = TalkString.IndexOf("{/font}", num + 3);
                        if (num == -1)
                        {
                            num = TalkString.Length;
                        }
                        for (; length < num; length++)
                        {
                            stringBuilder1.Append(TalkString[length]);
                        }
                        length += 7;
                        Run run6 = new Run(stringBuilder1.ToString())
                        {
                            Foreground = new SolidColorBrush(Color.FromArgb(byte.MaxValue, byte.Parse(str2.Substring(1, 2), NumberStyles.HexNumber), byte.Parse(str2.Substring(3, 2), NumberStyles.HexNumber), byte.Parse(str2.Substring(5, 2), NumberStyles.HexNumber)))
                        };
                        inlines.Add(run6);
                        stringBuilder1.Clear();
                    }
                    else if (str == "{string}")
                    {
                        num = TalkString.IndexOf("{/string}", length);
                        if (num == -1)
                        {
                            length -= str.Length;
                            for (int i = 0; i < str.Length; i++)
                            {
                                stringBuilder1.Append(TalkString[length++]);
                            }
                        }
                        else
                        {
                            string str6 = TalkString.Substring(length, num - length);
                            string value = "Unknown String";
                            uint num4 = 0u;
                            if (uint.TryParse(str6, out num4))
                            {
                                Talktable.TalktableString sTR = Library.GetString(Settings.Default.Language, num4);
                                if (sTR != null)
                                {
                                    value = sTR.Value;
                                }
                            }
                            value = value.Replace("<i>", "{i}").Replace("</i>", "{/i}");
                            value = value.Replace("<b>", "{b}").Replace("</b>", "{/b}");
                            value = value.Replace("<br>", "{linebreak}");
                            TalkString = TalkString.Replace("<font>", "{font}").Replace("<font", "{font").Replace("\">", "\"}")
                                .Replace("</font>", "{/font}");
                            length -= str.Length;
                            TalkString = TalkString.Replace("{string}" + str6 + "{/string}", value);
                        }
                    }
                    else if (str == "{linebreak}")
                    {
                        stringBuilder1.Append("\n");
                    }
                    else if (str != "{blank}")
                    {
                        switch (str)
                        {
                            case "{pc}":
                                {
                                    num = TalkString.IndexOf("{/pc}", length);
                                    string str7 = "";
                                    if (num == -1)
                                    {
                                        length -= str.Length;
                                        for (int j = 0; j < str.Length; j++)
                                        {
                                            stringBuilder1.Append(TalkString[length++]);
                                        }
                                    }
                                    else
                                    {
                                        str7 = TalkString.Substring(length, num - length);
                                        TalkString = TalkString.Replace("{pc}" + str7 + "{/pc}", (Device == "PC") ? str7 : "");
                                        length -= str.Length;
                                    }
                                    break;
                                }
                            case "{notpc}":
                                {
                                    num = TalkString.IndexOf("{/notpc}", length);
                                    string str8 = "";
                                    if (num == -1)
                                    {
                                        length -= str.Length;
                                        for (int k = 0; k < str.Length; k++)
                                        {
                                            stringBuilder1.Append(TalkString[length++]);
                                        }
                                    }
                                    else
                                    {
                                        str8 = TalkString.Substring(length, num - length);
                                        TalkString = TalkString.Replace("{notpc}" + str8 + "{/notpc}", (Device != "PC") ? str8 : "");
                                        length -= str.Length;
                                    }
                                    break;
                                }
                            case "{ps3}":
                                {
                                    num = TalkString.IndexOf("{/ps3}", length);
                                    string str9 = "";
                                    if (num == -1)
                                    {
                                        length -= str.Length;
                                        for (int l = 0; l < str.Length; l++)
                                        {
                                            stringBuilder1.Append(TalkString[length++]);
                                        }
                                    }
                                    else
                                    {
                                        str9 = TalkString.Substring(length, num - length);
                                        TalkString = TalkString.Replace("{ps3}" + str9 + "{/ps3}", (Device == "PS3") ? str9 : "");
                                        length -= str.Length;
                                    }
                                    break;
                                }
                            case "{ps4}":
                                {
                                    num = TalkString.IndexOf("{/ps4}", length);
                                    string str10 = "";
                                    if (num == -1)
                                    {
                                        length -= str.Length;
                                        for (int m = 0; m < str.Length; m++)
                                        {
                                            stringBuilder1.Append(TalkString[length++]);
                                        }
                                    }
                                    else
                                    {
                                        str10 = TalkString.Substring(length, num - length);
                                        TalkString = TalkString.Replace("{ps4}" + str10 + "{/ps4}", (Device == "PS4") ? str10 : "");
                                        length -= str.Length;
                                    }
                                    break;
                                }
                            case "{xbox360}":
                                {
                                    num = TalkString.IndexOf("{/xbox360}", length);
                                    string str11 = "";
                                    if (num == -1)
                                    {
                                        length -= str.Length;
                                        for (int n = 0; n < str.Length; n++)
                                        {
                                            stringBuilder1.Append(TalkString[length++]);
                                        }
                                    }
                                    else
                                    {
                                        str11 = TalkString.Substring(length, num - length);
                                        TalkString = TalkString.Replace("{xbox360}" + str11 + "{/xbox360}", (Device == "XBOX360") ? str11 : "");
                                        length -= str.Length;
                                    }
                                    break;
                                }
                            case "{xboxone}":
                                {
                                    num = TalkString.IndexOf("{/xboxone}", length);
                                    string str12 = "";
                                    if (num == -1)
                                    {
                                        length -= str.Length;
                                        for (int o = 0; o < str.Length; o++)
                                        {
                                            stringBuilder1.Append(TalkString[length++]);
                                        }
                                    }
                                    else
                                    {
                                        str12 = TalkString.Substring(length, num - length);
                                        TalkString = TalkString.Replace("{xboxone}" + str12 + "{/xboxone}", (Device == "XBOXONE") ? str12 : "");
                                        length -= str.Length;
                                    }
                                    break;
                                }
                            case "{anyxbox}":
                                {
                                    num = TalkString.IndexOf("{/anyxbox}", length);
                                    string str3 = "";
                                    if (num == -1)
                                    {
                                        length -= str.Length;
                                        for (int p = 0; p < str.Length; p++)
                                        {
                                            stringBuilder1.Append(TalkString[length++]);
                                        }
                                    }
                                    else
                                    {
                                        str3 = TalkString.Substring(length, num - length);
                                        TalkString = TalkString.Replace("{anyxbox}" + str3 + "{/anyxbox}", (Device == "XBOX360" || Device == "XBOXONE") ? str3 : "");
                                        length -= str.Length;
                                    }
                                    break;
                                }
                            default:
                                {
                                    if (str != "{anyplaystation}")
                                    {
                                        length -= str.Length;
                                        for (int q = 0; q < str.Length; q++)
                                        {
                                            stringBuilder1.Append(TalkString[length++]);
                                        }
                                        break;
                                    }
                                    num = TalkString.IndexOf("{/anyplaystation}", length);
                                    string str4 = "";
                                    if (num == -1)
                                    {
                                        length -= str.Length;
                                        for (int r = 0; r < str.Length; r++)
                                        {
                                            stringBuilder1.Append(TalkString[length++]);
                                        }
                                    }
                                    else
                                    {
                                        str4 = TalkString.Substring(length, num - length);
                                        TalkString = TalkString.Replace("{anyplaystation}" + str4 + "{/anyplaystation}", (Device == "PS3" || Device == "PS4") ? str4 : "");
                                        length -= str.Length;
                                    }
                                    break;
                                }
                        }
                    }
                    if (length >= TalkString.Length)
                    {
                        for (; length < TalkString.Length; length++)
                        {
                            stringBuilder1.Append(TalkString[length]);
                        }
                        run = new Run(stringBuilder1.ToString())
                        {
                            Foreground = new SolidColorBrush(Colors.White)
                        };
                        inlines.Add(run);
                        return inlines;
                    }
                    num = TalkString.IndexOf('{', length);
                    num2 = TalkString.IndexOf('}', length);
                }
            }
            for (; length < TalkString.Length; length++)
            {
                stringBuilder1.Append(TalkString[length]);
            }
            run = new Run(stringBuilder1.ToString())
            {
                Foreground = new SolidColorBrush(Colors.White)
            };
            inlines.Add(run);
            return inlines;
        }

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        public static bool IsKeyDown(Keys key)
        {
            return (GetAsyncKeyState(key) & 0x8000) != 0;
        }

        public static SlimDX.Vector3 ToSlimDXVector3(this DAI.AssetLibrary.Assets.Bases.Vector3 vec3)
        {
            return new SlimDX.Vector3(vec3.X, vec3.Y, vec3.Z);
        }

        public static SlimDX.Vector2 ToSlimDXVector2(this DAI.AssetLibrary.Assets.Bases.Vector2 vec2)
        {
            return new SlimDX.Vector2(vec2.X, vec2.Y);
        }

        public static SlimDX.Vector4 ToSlimDXVector4(this DAI.AssetLibrary.Assets.Bases.Vector4 vec4)
        {
            return new SlimDX.Vector4(vec4.X, vec4.Y, vec4.Z, vec4.W);
        }

        public static string MetaToString(byte[] InMeta)
        {
            if (InMeta == null)
            {
                return string.Empty;
            }
            string str = "";
            for (int i = 0; i < InMeta.Length; i++)
            {
                str += InMeta[i].ToString("X2");
            }
            return str;
        }
    }
}

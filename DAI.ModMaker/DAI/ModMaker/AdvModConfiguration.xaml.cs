using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

using DAI.ModMaker.Controls;
using DAI.ModMaker.DAIMod;

using Microsoft.Win32;

namespace DAI.ModMaker
{
	public partial class AdvModConfiguration : Window, IComponentConnector
	{
		public ModJob CurrentMod;

		public bool Cancelled;

		private ModScript CompiledModScript;

		public AdvModConfiguration(string ModPath)
		{
			InitializeComponent();
			ResourceDataHexControl.MenuBarHidden = true;
			// TODO: lol wtf don't create a new one from file 
			CurrentMod = ModJob.CreateFromFile(ModPath);
			CurrentMod.FileName = ModPath;
			Cancelled = true;
			ModTitleTextBox.Text = CurrentMod.Meta.Details.Name;
			ModAuthorTextBox.Text = CurrentMod.Meta.Details.Author;
			ModVersionTextBox.Text = CurrentMod.Meta.Details.Version;
			ModDescriptionTextBox.Text = CurrentMod.Meta.Details.Description;
			for (int i = 0; i < CurrentMod.Data.Count; i++)
			{
				string str = "Unbound_Data_" + i;
				foreach (ModResourceEntry resource in CurrentMod.Meta.Resources)
				{
					if (resource.ResourceID == i)
					{
						str = "Bound_Data_" + i;
						break;
					}
				}
				ResourceDataListBox.Items.Add(str);
			}
			ScriptTextBox.Text = CurrentMod.Script;
			string[] strArrays = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Templates", "*.cs", SearchOption.AllDirectories);
			for (int j = 0; j < strArrays.Length; j++)
			{
				FileInfo fileInfo = new FileInfo(strArrays[j]);
				TemplateComboBox.Items.Add(fileInfo.Name);
			}
		}

		private void AddDataButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "*.*|*.*",
				Title = "Resource Binary"
			};
			if (openFileDialog.ShowDialog() == true)
			{
				FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
				byte[] numArray = new byte[fileStream.Length];
				fileStream.Read(numArray, 0, (int)fileStream.Length);
				fileStream.Close();
				CurrentMod.Data.Add(DAI.AssetLibrary.Utilities.Utilities.CompressData(numArray));
				int count = CurrentMod.Data.Count - 1;
				ResourceDataListBox.Items.Add("Unbound_Data_" + count);
				ResourceDataListBox.SelectedIndex = CurrentMod.Data.Count - 1;
			}
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void CompileButton_Clicked(object sender, RoutedEventArgs e)
		{
			ScriptLogTextBox.Clear();
			try
			{
				CompiledModScript = Scripting.GetModScriptObject(ScriptTextBox.Text);
				TestButton.IsEnabled = true;
				CurrentMod.Script = ScriptTextBox.Text;
				WriteLogEntry("Build successful");
			}
			catch (Exception exception)
			{
				TestButton.IsEnabled = false;
				WriteLogEntry(exception.Message);
			}
		}

		private void RefreshData()
		{
			if (ResourceDataListBox.SelectedIndex == -1)
			{
				ResourceBindingTextBox.Text = "";
				ResourceDataHexControl.ClearByteData();
				return;
			}
			ResourceBindingTextBox.Text = "[Unbound]";
			int num = 0;
			ModResourceEntry modResourceEntry = null;
			foreach (ModResourceEntry resource in CurrentMod.Meta.Resources)
			{
				if (resource.ResourceID != ResourceDataListBox.SelectedIndex)
				{
					num++;
					continue;
				}
				modResourceEntry = resource;
				break;
			}
			if (modResourceEntry != null)
			{
				ResourceBindingTextBox.Text = "[" + num + "] " + modResourceEntry.Name;
			}
			byte[] numArray = DAI.AssetLibrary.Utilities.Utilities.DecompressData(CurrentMod.Data[ResourceDataListBox.SelectedIndex], -1L);
			ResourceDataHexControl.SetByteData(numArray);
		}

		private void RemoveDataButton_Click(object sender, RoutedEventArgs e)
		{
			if (ResourceDataListBox.SelectedIndex == -1)
			{
				return;
			}
			CurrentMod.Data.RemoveAt(ResourceDataListBox.SelectedIndex);
			ResourceDataListBox.Items.Clear();
			for (int i = 0; i < CurrentMod.Data.Count; i++)
			{
				string str = "Unbound_Data_" + i;
				foreach (ModResourceEntry resource in CurrentMod.Meta.Resources)
				{
					if (resource.ResourceID == i)
					{
						str = "Bound_Data_" + i;
						break;
					}
				}
				ResourceDataListBox.Items.Add(str);
			}
			ResourceDataListBox.SelectedIndex = -1;
			RefreshData();
		}

		private void ResourceDataListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ResourceDataListBox.SelectedIndex == -1)
			{
				RemoveDataButton.IsEnabled = false;
				return;
			}
			RemoveDataButton.IsEnabled = false;
			if (((string)ResourceDataListBox.SelectedItem).Contains("Unbound"))
			{
				RemoveDataButton.IsEnabled = true;
			}
			RefreshData();
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			CurrentMod.Meta.Details.Name = ModTitleTextBox.Text;
			CurrentMod.Meta.Details.Author = ModAuthorTextBox.Text;
			CurrentMod.Meta.Details.Version = ModVersionTextBox.Text;
			CurrentMod.Meta.Details.Description = ModDescriptionTextBox.Text;
			CurrentMod.Script = ScriptTextBox.Text;
			Cancelled = false;
			for (int i = 0; i < CurrentMod.Meta.Resources.Count; i++)
			{
				CurrentMod.Data[CurrentMod.Meta.Resources[i].ResourceID] = null;
			}
			CurrentMod.Data.RemoveAll((byte[] A) => A == null);
			CurrentMod.Meta.Resources.Clear();
			CurrentMod.Meta.Bundles.Clear();
			// TODO: This neglects any changes made in the data tab
			PatchPayloadData Payload = new PatchPayloadData
			{
				OutputPath = CurrentMod.FileName,
				Mod = CurrentMod
			};
			ModParser.DoSavePatch(Payload);
			MessageBox.Show("Changes successfully saved to " + CurrentMod.FileName);
			Close();
		}

		private void TemplateChooseButton_Clicked(object sender, RoutedEventArgs e)
		{
			if (TemplateComboBox.SelectedIndex >= 1)
			{
				string str1 = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Templates\\" + TemplateComboBox.SelectedItem);
				ScriptTextBox.Text = str1;
			}
		}

		private void TestButton_Clicked(object sender, RoutedEventArgs e)
		{
			if (CompiledModScript != null)
			{
				Scripting.CurrentMod = CurrentMod;
				Scripting.ScriptLogTextBox = ScriptLogTextBox;
				Scripting.LogLn("Executing ModScript::ConstructUI");
				ModConfigElementsList modConfigElementsList = new ModConfigElementsList();
				CompiledModScript.ConstructUI(modConfigElementsList);
				TestModConfigWindow testModConfigWindow = new TestModConfigWindow(modConfigElementsList, Scripting.ConfigValues);
				testModConfigWindow.ShowDialog();
				Scripting.ConfigValues = testModConfigWindow.ConfigValues;
				Scripting.LogLn("Executing ModScript::RunScript");
				CompiledModScript.RunScript();
			}
		}

		private void WriteLogEntry(string InStr)
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
}

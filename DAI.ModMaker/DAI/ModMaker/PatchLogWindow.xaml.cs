using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace DAI.ModMaker
{
	public partial class PatchLogWindow : Window, IComponentConnector
	{
		public PatchLogWindow(List<string> InLogEntries)
		{
			InitializeComponent();
			foreach (string inLogEntry in InLogEntries)
			{
				TextBox patchLogTextBox = PatchLogTextBox;
				patchLogTextBox.Text = patchLogTextBox.Text + inLogEntry + "\n";
			}
		}

		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}

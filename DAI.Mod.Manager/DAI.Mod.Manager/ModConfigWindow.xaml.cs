using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

using DAI.Controls;
using DAI.Mod;

namespace DAI.Mod.Manager {
    public partial class ModConfigWindow : Window, IComponentConnector {
        public Dictionary<string, object> ConfigValues;

        public List<UIElement> ControlsList;

        public ModConfigElementsList ConfigParams;

        public ModConfigWindow(ModConfigElementsList InParams, Dictionary<string, object> InCurrentValues) {
            double height = 20.0;
            InitializeComponent();
            ConfigValues = InCurrentValues ?? new Dictionary<string, object>();
            ConfigParams = InParams;
            ControlsList = new List<UIElement>();
            foreach (ModConfigElement uIElement in InParams.UIElements) {
                TextBlock element = new TextBlock {
                    Text = uIElement.ParameterPrettyName,
                    Height = height,
                    Margin = new Thickness(2.0)
                };
                LabelsStackPanel.Children.Add(element);
                if (!ConfigValues.ContainsKey(uIElement.ParameterName)) {
                    ConfigValues.Add(uIElement.ParameterName, uIElement.ParameterDefaultValue);
                }
                if (uIElement.ParameterType == typeof(int)) {
                    TextBox textBox = new TextBox {
                        Height = height,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(2.0),
                        Text = ConfigValues[uIElement.ParameterName].ToString()
                    };
                    ControlsStackPanel.Children.Add(textBox);
                    ControlsList.Add(textBox);
                } else if (uIElement.ParameterType == typeof(float)) {
                    TextBox textBox2 = new TextBox {
                        Height = height,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(2.0),
                        Text = ((float)ConfigValues[uIElement.ParameterName]).ToString("F3")
                    };
                    ControlsStackPanel.Children.Add(textBox2);
                    ControlsList.Add(textBox2);
                } else if (uIElement.ParameterType == typeof(bool)) {
                    CheckBox checkBox = new CheckBox {
                        Height = height,
                        Margin = new Thickness(2.0),
                        IsChecked = (bool)ConfigValues[uIElement.ParameterName]
                    };
                    ControlsStackPanel.Children.Add(checkBox);
                    ControlsList.Add(checkBox);
                } else if (uIElement.ParameterType == typeof(string)) {
                    TextBox textBox3 = new TextBox {
                        Height = height,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(2.0),
                        Text = ConfigValues[uIElement.ParameterName].ToString()
                    };
                    ControlsStackPanel.Children.Add(textBox3);
                    ControlsList.Add(textBox3);
                } else if (uIElement.ParameterType.IsSubclassOf(typeof(Enum))) {
                    string[] enumNames = uIElement.ParameterType.GetEnumNames();
                    ComboBox comboBox = new ComboBox {
                        Height = height,
                        Margin = new Thickness(2.0),
                        ItemsSource = enumNames,
                        SelectedIndex = (int)ConfigValues[uIElement.ParameterName]
                    };
                    ControlsStackPanel.Children.Add(comboBox);
                    ControlsList.Add(comboBox);
                } else if (uIElement.ParameterType == typeof(Mod.Color)) {
                    Mod.Color color = (Mod.Color)uIElement.ParameterDefaultValue;
                    Button button = new Button();
                    button.Margin = new Thickness(2.0);
                    button.Height = height;
                    button.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb((byte)((double)color.A * 255.0), (byte)((double)color.R * 255.0), (byte)((double)color.G * 255.0), (byte)((double)color.B * 255.0)));
                    button.Click += ColorControl_MouseDown;
                    ControlsStackPanel.Children.Add(button);
                    ControlsList.Add(button);
                }
            }
        }

        private void ColorControl_MouseDown(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            ColorPickerDialog colorPickerDialog = new ColorPickerDialog(((SolidColorBrush)button.Background).Color);
            bool? flag = colorPickerDialog.ShowDialog();
            if (flag.GetValueOrDefault() && (flag.HasValue ? true : false)) {
                button.Background = new SolidColorBrush(colorPickerDialog.SelectedColor);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            int num = 0;
            while (num < ConfigParams.UIElements.Count) {
                ModConfigElement modConfigElement = ConfigParams.UIElements[num];
                if (modConfigElement.ParameterType == typeof(int)) {
                    TextBox textBox = ControlsList[num] as TextBox;
                    if (!int.TryParse(textBox.Text, out var result)) {
                        MessageBox.Show("Invalid value found for " + modConfigElement.ParameterPrettyName);
                        return;
                    }
                    int num2 = (int)modConfigElement.ParameterMinValue;
                    int num3 = (int)modConfigElement.ParameterMaxValue;
                    if (result < num2 || result > num3) {
                        MessageBox.Show(modConfigElement.ParameterPrettyName + " is out of range (" + num2 + " - " + num3 + ")");
                        return;
                    }
                    ConfigValues[modConfigElement.ParameterName] = result;
                } else if (modConfigElement.ParameterType == typeof(float)) {
                    TextBox textBox2 = ControlsList[num] as TextBox;
                    if (!float.TryParse(textBox2.Text, out var result2)) {
                        MessageBox.Show("Invalid value found for " + modConfigElement.ParameterPrettyName);
                        return;
                    }
                    float num4 = (float)modConfigElement.ParameterMinValue;
                    float num5 = (float)modConfigElement.ParameterMaxValue;
                    if ((double)result2 < (double)num4 || (double)result2 > (double)num5) {
                        MessageBox.Show(modConfigElement.ParameterPrettyName + " is out of range (" + num4 + " - " + num5 + ")");
                        return;
                    }
                    ConfigValues[modConfigElement.ParameterName] = result2;
                } else if (modConfigElement.ParameterType == typeof(bool)) {
                    CheckBox checkBox = ControlsList[num] as CheckBox;
                    ConfigValues[modConfigElement.ParameterName] = checkBox.IsChecked.Value;
                } else if (modConfigElement.ParameterType == typeof(string)) {
                    TextBox textBox3 = ControlsList[num] as TextBox;
                    ConfigValues[modConfigElement.ParameterName] = textBox3.Text;
                } else if (modConfigElement.ParameterType.IsSubclassOf(typeof(Enum))) {
                    ComboBox comboBox = ControlsList[num] as ComboBox;
                    ConfigValues[modConfigElement.ParameterName] = comboBox.SelectedIndex;
                } else if (modConfigElement.ParameterType == typeof(Mod.Color)) {
                    SolidColorBrush solidColorBrush = (SolidColorBrush)(ControlsList[num] as Button).Background;
                    Mod.Color value = new Mod.Color((float)(int)solidColorBrush.Color.R / 255f, (float)(int)solidColorBrush.Color.G / 255f, (float)(int)solidColorBrush.Color.B / 255f, (float)(int)solidColorBrush.Color.A / 255f);
                    ConfigValues[modConfigElement.ParameterName] = value;
                }
                int num6 = num + 1;
                num = num6;
            }
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

using DAI.ModMaker.Controls;
using DAI.ModMaker.DAIMod;

namespace DAI.ModMaker
{
    public partial class TestModConfigWindow : Window, IComponentConnector
    {
        public Dictionary<string, object> ConfigValues;

        public List<UIElement> ControlsList;

        public ModConfigElementsList ConfigParams;

        public TestModConfigWindow(ModConfigElementsList InParams, Dictionary<string, object> InCurrentValues)
        {
            double num = 20.0;
            InitializeComponent();
            if (InCurrentValues == null)
            {
                ConfigValues = new Dictionary<string, object>();
            }
            else
            {
                ConfigValues = InCurrentValues;
            }
            ConfigParams = InParams;
            ControlsList = new List<UIElement>();
            foreach (ModConfigElement uIElement in InParams.UIElements)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = uIElement.ParameterPrettyName,
                    Height = num,
                    Margin = new Thickness(2.0)
                };
                LabelsStackPanel.Children.Add(textBlock);
                if (!ConfigValues.ContainsKey(uIElement.ParameterName))
                {
                    ConfigValues.Add(uIElement.ParameterName, uIElement.ParameterDefaultValue);
                }
                if (uIElement.ParameterType == typeof(int))
                {
                    TextBox textBox = new TextBox
                    {
                        Height = num,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(2.0),
                        Text = ConfigValues[uIElement.ParameterName].ToString()
                    };
                    ControlsStackPanel.Children.Add(textBox);
                    ControlsList.Add(textBox);
                }
                else if (uIElement.ParameterType == typeof(float))
                {
                    TextBox str = new TextBox
                    {
                        Height = num,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(2.0)
                    };
                    str.Text = ((float)ConfigValues[uIElement.ParameterName]).ToString("F3");
                    ControlsStackPanel.Children.Add(str);
                    ControlsList.Add(str);
                }
                else if (uIElement.ParameterType == typeof(bool))
                {
                    CheckBox checkBox = new CheckBox
                    {
                        Height = num,
                        Margin = new Thickness(2.0),
                        IsChecked = (bool)ConfigValues[uIElement.ParameterName]
                    };
                    ControlsStackPanel.Children.Add(checkBox);
                    ControlsList.Add(checkBox);
                }
                else if (uIElement.ParameterType == typeof(string))
                {
                    TextBox textBox2 = new TextBox
                    {
                        Height = num,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(2.0),
                        Text = ConfigValues[uIElement.ParameterName].ToString()
                    };
                    ControlsStackPanel.Children.Add(textBox2);
                    ControlsList.Add(textBox2);
                }
                else if (!uIElement.ParameterType.IsSubclassOf(typeof(Enum)))
                {
                    if (!(uIElement.ParameterType != typeof(DAI.ModMaker.DAIMod.Color)))
                    {
                        DAI.ModMaker.DAIMod.Color parameterDefaultValue = (DAI.ModMaker.DAIMod.Color)uIElement.ParameterDefaultValue;
                        Button button = new Button
                        {
                            Margin = new Thickness(2.0),
                            Height = num,
                            Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(Convert.ToByte(parameterDefaultValue.A * 255f), (byte)(parameterDefaultValue.R * 255f), (byte)(parameterDefaultValue.G * 255f), (byte)(parameterDefaultValue.B * 255f)))
                        };
                        button.Click += ColorControl_MouseDown;
                        ControlsStackPanel.Children.Add(button);
                        ControlsList.Add(button);
                    }
                }
                else
                {
                    string[] enumNames = uIElement.ParameterType.GetEnumNames();
                    ComboBox comboBox = new ComboBox
                    {
                        Height = num,
                        Margin = new Thickness(2.0),
                        ItemsSource = enumNames,
                        SelectedIndex = (int)uIElement.ParameterDefaultValue
                    };
                    ControlsStackPanel.Children.Add(comboBox);
                    ControlsList.Add(comboBox);
                }
            }
        }

        private void ColorControl_MouseDown(object sender, RoutedEventArgs e)
        {
            Button solidColorBrush = (Button)sender;
            ColorPickerDialog colorPickerDialog = new ColorPickerDialog(((SolidColorBrush)solidColorBrush.Background).Color);
            if (colorPickerDialog.ShowDialog() == true)
            {
                solidColorBrush.Background = new SolidColorBrush(colorPickerDialog.SelectedColor);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ConfigParams.UIElements.Count; i++)
            {
                ModConfigElement item = ConfigParams.UIElements[i];
                if (item.ParameterType == typeof(int))
                {
                    TextBox obj = ControlsList[i] as TextBox;
                    int num = 0;
                    if (!int.TryParse(obj.Text, out num))
                    {
                        MessageBox.Show("Invalid value found for " + item.ParameterPrettyName);
                        return;
                    }
                    int parameterMinValue = (int)item.ParameterMinValue;
                    int parameterMaxValue = (int)item.ParameterMaxValue;
                    if (num < parameterMinValue || num > parameterMaxValue)
                    {
                        MessageBox.Show(item.ParameterPrettyName + " is out of range (" + parameterMinValue + " - " + parameterMaxValue + ")");
                        return;
                    }
                    ConfigValues[item.ParameterName] = num;
                }
                else if (item.ParameterType == typeof(float))
                {
                    TextBox obj2 = ControlsList[i] as TextBox;
                    float single = 0f;
                    if (!float.TryParse(obj2.Text, out single))
                    {
                        MessageBox.Show("Invalid value found for " + item.ParameterPrettyName);
                        return;
                    }
                    float parameterMinValue2 = (float)item.ParameterMinValue;
                    float parameterMaxValue2 = (float)item.ParameterMaxValue;
                    if (single < parameterMinValue2 || single > parameterMaxValue2)
                    {
                        MessageBox.Show(item.ParameterPrettyName + " is out of range (" + parameterMinValue2 + " - " + parameterMaxValue2 + ")");
                        return;
                    }
                    ConfigValues[item.ParameterName] = single;
                }
                else if (item.ParameterType == typeof(bool))
                {
                    CheckBox checkBox = ControlsList[i] as CheckBox;
                    ConfigValues[item.ParameterName] = checkBox.IsChecked.Value;
                }
                else if (item.ParameterType == typeof(string))
                {
                    TextBox textBox1 = ControlsList[i] as TextBox;
                    ConfigValues[item.ParameterName] = textBox1.Text;
                }
                else if (item.ParameterType.IsSubclassOf(typeof(Enum)))
                {
                    ComboBox comboBox = ControlsList[i] as ComboBox;
                    ConfigValues[item.ParameterName] = comboBox.SelectedIndex;
                }
                else if (item.ParameterType == typeof(DAI.ModMaker.DAIMod.Color))
                {
                    SolidColorBrush obj3 = (SolidColorBrush)(ControlsList[i] as Button).Background;
                    float r = (float)(int)obj3.Color.R / 255f;
                    float g = (float)(int)obj3.Color.G / 255f;
                    float b = (float)(int)obj3.Color.B / 255f;
                    DAI.ModMaker.DAIMod.Color color1 = new DAI.ModMaker.DAIMod.Color(r, g, b, (float)(int)obj3.Color.A / 255f);
                    ConfigValues[item.ParameterName] = color1;
                }
            }
            Close();
        }
    }
}

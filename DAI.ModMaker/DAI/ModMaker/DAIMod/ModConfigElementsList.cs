using System;
using System.Collections.Generic;

namespace DAI.ModMaker.DAIMod
{
    public class ModConfigElementsList
    {
        public List<ModConfigElement> UIElements { get; private set; }

        public ModConfigElementsList()
        {
            UIElements = new List<ModConfigElement>();
        }

        public void AddBoolElement(string InVarName, string InPrettyName, bool InDefaultValue)
        {
            ModConfigElement modConfigElement = new ModConfigElement
            {
                ParameterName = InVarName,
                ParameterType = typeof(bool),
                ParameterDefaultValue = InDefaultValue,
                ParameterPrettyName = InPrettyName
            };
            UIElements.Add(modConfigElement);
        }

        public void AddColorElement(string InVarName, string InPrettyName, Color InDefaultValue)
        {
            ModConfigElement modConfigElement = new ModConfigElement
            {
                ParameterName = InVarName,
                ParameterType = typeof(Color),
                ParameterDefaultValue = InDefaultValue,
                ParameterPrettyName = InPrettyName
            };
            UIElements.Add(modConfigElement);
        }

        public void AddEnumElement(string InVarName, string InPrettyName, Type InEnumType, int InDefaultIndex)
        {
            ModConfigElement modConfigElement = new ModConfigElement
            {
                ParameterName = InVarName,
                ParameterType = InEnumType,
                ParameterDefaultValue = InDefaultIndex,
                ParameterPrettyName = InPrettyName
            };
            UIElements.Add(modConfigElement);
        }

        public void AddFloatElement(string InVarName, string InPrettyName, float InDefaultValue, float InMinValue, float InMaxValue)
        {
            ModConfigElement modConfigElement = new ModConfigElement
            {
                ParameterName = InVarName,
                ParameterType = typeof(float),
                ParameterDefaultValue = InDefaultValue,
                ParameterPrettyName = InPrettyName,
                ParameterMinValue = InMinValue,
                ParameterMaxValue = InMaxValue
            };
            UIElements.Add(modConfigElement);
        }

        public void AddIntElement(string InVarName, string InPrettyName, int InDefaultValue, int InMinValue, int InMaxValue)
        {
            ModConfigElement modConfigElement = new ModConfigElement
            {
                ParameterName = InVarName,
                ParameterType = typeof(int),
                ParameterDefaultValue = InDefaultValue,
                ParameterPrettyName = InPrettyName,
                ParameterMinValue = InMinValue,
                ParameterMaxValue = InMaxValue
            };
            UIElements.Add(modConfigElement);
        }

        public void AddStringElement(string InVarName, string InPrettyName, string InDefaultValue)
        {
            ModConfigElement modConfigElement = new ModConfigElement
            {
                ParameterName = InVarName,
                ParameterType = typeof(string),
                ParameterDefaultValue = InDefaultValue,
                ParameterPrettyName = InPrettyName
            };
            UIElements.Add(modConfigElement);
        }
    }
}

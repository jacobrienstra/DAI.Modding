using System;

namespace DAI.ModMaker.DAIMod
{
    public class ModConfigElement
    {
        public object ParameterDefaultValue { get; set; }

        public object ParameterMaxValue { get; set; }

        public object ParameterMinValue { get; set; }

        public string ParameterName { get; set; }

        public string ParameterPrettyName { get; set; }

        public Type ParameterType { get; set; }
    }
}

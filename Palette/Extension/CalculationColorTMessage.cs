using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.Extension
{
    internal class CalculationColorTMessage
    {

        public CalculationColor CalType;

        public object Parameter { get; set; }

        public CalculationColorTMessage(CalculationColor calType, object parameter)
        {
            Parameter = parameter;
            CalType = calType;
        }
        public CalculationColorTMessage()
        {

        }

        public Action action { get; set; }

    }

    public enum CalculationColor
    {
        Complementary,
        Adjacent,
        Contrasting,
        Medium
    }
}

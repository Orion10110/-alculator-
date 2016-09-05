using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Calc.Model
{
    class SizeContentConverter : IMultiValueConverter

    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double result = 15;
            double value1 = (double)values[0];
            double value2 = (double)values[1];
            double sum = value1 + value2;
            if (sum < 800)
            {
                result = ((double)values[0] + (double)values[1]) / 29;
            }
           else if(sum > 800 && sum<1600)
            {
                result = ((double)values[0] + (double)values[1]) / 33;
            }
            else if (sum> 1600)
            {
                result = ((double)values[0] + (double)values[1]) / 39;
            }
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

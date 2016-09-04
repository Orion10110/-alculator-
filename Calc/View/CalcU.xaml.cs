using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc.View
{
    /// <summary>
    /// Логика взаимодействия для CalcU.xaml
    /// </summary>
    public partial class CalcU : UserControl,INotifyPropertyChanged
    {
        public CalcU()
        {
            InitializeComponent();
            Dat.DataContext = this;
        }

        private string val1 = "0";
        private string val2 = "0";
        private string stroka="0";

        public string Stroka
        {
            get { return stroka; }
            set { stroka = value;
                OnPropertyChanged("Stroka");
            }
        }

        private string operat;
        private bool valueFir = true;
        private bool sch;

        public string Operat
        {
            get { return operat; }
            set { operat = value;
                OnPropertyChanged("Operat");
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button buttonClick = (Button)sender;
            string v = buttonClick.Content.ToString();
            if (valueFir)
            {
                Stroka = "0";
                valueFir = false;
            }
            if (stroka.Contains(",") && v == ",")
            {
                return;
            }
           
            if (stroka == "0" && v != ",")
            {
                Stroka = v;
            }
            else
            {
                Stroka += v;
            }

            if (String.IsNullOrEmpty(operat))
            {


                val1 = Stroka;
            }
            else {
                val2 = stroka;
                sch = true;

            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button buttonClick = (Button)sender;
            string v = buttonClick.Content.ToString();
            val2 = Stroka;
            if (sch)
            {
                Calculate();
            }
            
            valueFir = true;
            Operat = v;

        }

        private void Calculate()
        {
            double value1 = Double.Parse(val1);
            double value2 = Double.Parse(val2);
            double res = 0;
            switch (operat)
            {
                case "+": res = value1 + value2; break;
                case "-": res = value1 - value2; break;
                case "/": res = value1 / value2; break;
                case "*": res = value1 * value2; break;
                default:
                    break;
            }
           
            Stroka = res.ToString();
            val1 = Stroka;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Calculate();
            sch = false;
            valueFir = true;
            operat = null;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Stroka = "0";
            if (String.IsNullOrEmpty(operat))
            {
                val1 = Stroka;
            }
            else {
                val2 = stroka;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            sch = false;
            valueFir = true;
            operat = null;
            Stroka = "0";
            val1 = "0";
            val2 = "0";

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            
            if (Stroka.Length > 1) {
                string temp = Stroka.Substring(0, Stroka.Length-1);
                if (String.IsNullOrEmpty(operat))
                {
                   Stroka = val1 = temp;
                }
                else {
                    Stroka = val2 = temp;
                }
            }else
            {
                if (String.IsNullOrEmpty(operat))
                {
                    Stroka = val1 = "0";
                }
                else {
                    Stroka = val2 = "0";
                }
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (Stroka[0] != '-')
            {
                if (String.IsNullOrEmpty(operat))
                {
                    Stroka = val1 = "-" + Stroka;
                }
                else {
                    Stroka = val2 = "-" + Stroka;
                }
            }
            else
            {
                string temp = Stroka.Substring(1, Stroka.Length-1);
                if (String.IsNullOrEmpty(operat))
                {
                    Stroka = val1 = temp;
                }
                else {
                    Stroka = val2 = temp;
                }
            }
           
        }
    }
}

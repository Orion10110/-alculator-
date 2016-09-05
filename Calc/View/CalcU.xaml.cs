using Calc.Model;
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
            Dat.DataContext = this.cal;
        }


        CalcModel cal = new CalcModel();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button buttonClick = (Button)sender;
            string v = buttonClick.Content.ToString();
            cal.InputValue(v);


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button buttonClick = (Button)sender;
            string v = buttonClick.Content.ToString();


            cal.Action(v);
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
            cal.Decide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            cal.ClearE();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            cal.Clear();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

            cal.Back();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            cal.ChangeSign();
           
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

            Button buttonClick = (Button)sender;
            string v = buttonClick.Content.ToString();
            cal.FOperat(v);
        }

        

      
    }
}

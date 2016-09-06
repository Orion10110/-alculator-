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
            Dat.Focus();
            
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

        private void Dat_KeyUp(object sender, KeyEventArgs e)
        {
           
            //var s = e.Key;
            //if(e.Key == Key.)
            
            //MessageBox.Show(conver.ConvertToString(e.Key));
        }

        private void userControl_KeyUp(object sender, KeyEventArgs e)
        {
            KeyConverter conver = new KeyConverter();
            if ((e.Key >= Key.D0 && e.Key <= Key.D9 && !(e.KeyboardDevice.Modifiers == ModifierKeys.Shift)) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                cal.InputValue((conver.ConvertToString(e.Key)));
            }
            if(e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            {
                switch (e.Key)
                {
                    case Key.D8:cal.Action("*"); break;
                    case Key.OemPlus:cal.Action("+");break;
                    case Key.D5:cal.FOperat("%"); break;
                    default: break;
                }
            }
            else if (e.Key == Key.OemPlus)
            {
                cal.Decide();
            }
            switch (conver.ConvertToString(e.Key))
            {

                case "Divide": cal.Action("/"); break;
                case "Multiply": cal.Action("*"); break;
                case "Add": cal.Action("+"); break;
                case "OemMinus":
                case "Subtract": cal.Action("-"); break;
                case "Return":cal.Decide(); break;
                case "Backspace": cal.Back(); break;


                //case "OemPlus":
                //case "OemMinus":

                default: 
                    break;
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            cal.MemoryClear();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            cal.MemoryRead();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            cal.MemorySave();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            cal.MemoryPlus();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            cal.MemorySub();
        }
    }
}

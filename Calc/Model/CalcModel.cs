using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Model
{
    public class CalcModel:INotifyPropertyChanged
    {
        private bool valueFir = true;
        private bool sch=false;
        private string val1 = "0";
        private string val2 = "0";
        private bool firstorcalc = true;
       

        private string histLine;
        public string HistLine
        {
            get { return histLine; }
           set
            {
                histLine = value;
                OnPropertyChanged("HistLine");
            }
        }

        private string line = "0";
        public string Line
        {
            get { return line; }
           set
            {
                line = value;
                OnPropertyChanged("Line");
            }
        }

        private string operat;
        public string Operat
        {
            get { return operat; }
           set
            {
                operat = value;
                OnPropertyChanged("Operat");
            }
        }


        private string memoryDate="0";

        public string MemoryDate
        {
            get { return memoryDate; }
           private set { memoryDate = value;
                OnPropertyChanged("MemoryDate");
            }
        }



        public void MemorySave()
        {

            MemoryDate = Line;
        }

        public void MemoryClear()
        {
            MemoryDate = "0";
        }

        public void MemoryRead()
        {
            Line = MemoryDate;
        }

        public void MemoryPlus()
        {
            double res =Double.Parse(MemoryDate) + Double.Parse(Line);
            MemoryDate = res.ToString();
        }

        public void MemorySub()
        {
            double res = Double.Parse(MemoryDate) - Double.Parse(Line);
            MemoryDate = res.ToString();
        }
        public void InputValue(string v)
        {
            if (valueFir)
            {
                Line = "0";
                valueFir = false;
            }
            if (line.Contains(",") && v == ",")
            {
                return;
            }

            if (line == "0" && v != ",")
            {
                Line = v;
            }
            else
            {
                Line += v;
            }

            if (String.IsNullOrEmpty(operat))
            {
                val1 = line;
            }
            else {
                val2 = line;
                sch = true;
            }
        } 

        public void Action(string v)
        {
            val2 = Line;
            if (sch)
            {
                Calculate();
                sch = false;
            }


            Operat = v;
            if ((!valueFir && !sch) || firstorcalc)
            {
                HistLine += val2 + " " + operat + " ";
                firstorcalc = false;
            }
            else
            {
                HistLine = HistLine.Substring(0, HistLine.Length - 2) + operat + " ";
            }
            valueFir = true;
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

            Line = res.ToString();
            val1 = Line;
            firstorcalc = true;

        }

        public void Decide()
        {
            Calculate();
            sch = false;
            valueFir = true;
            operat = null;
            HistLine = "";
        }

        private void ChangedLineValue(string newLine)
        {
            if (String.IsNullOrEmpty(operat))
            {
                Line = val1 = newLine;
            }
            else {
                Line = val2 = newLine;
            }
        }



        public void ClearE()
        {
            ChangedLineValue("0");
        }


        public void Clear()
        {
            sch = false;
            valueFir = true;
            operat = null;
            Line = "0";
            val1 = "0";
            val2 = "0";
            HistLine = "";
            firstorcalc = true;
        }

        public void Back()
        {
            if (Line.Length > 1)
            {
                string temp = Line.Substring(0, Line.Length - 1);
                ChangedLineValue(temp);
            }
            else
            {
                ChangedLineValue("0");
            }
        }

        public void ChangeSign()
        {
            if (Line[0] != '-')
            {
                if (String.IsNullOrEmpty(operat))
                {
                    Line = val1 = "-" + Line;
                }
                else {
                    Line = val2 = "-" + Line;
                }
            }
            else
            {
                string temp = Line.Substring(1, Line.Length - 1);
                ChangedLineValue(temp);
            }
        }


        public void FOperat(string v)
        {
            double res = Double.Parse(Line);

            switch (v)
            {
                case "1/x": res = 1 / res; break;
                case "%": res = Double.Parse(val1) / 100 * Double.Parse(val2); break;
                case "√": res = Math.Sqrt(res); break;
                default:
                    break;
            }

            ChangedLineValue(res.ToString());
            valueFir = true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

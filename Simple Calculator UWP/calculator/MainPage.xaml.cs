using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace calculator
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            result.Text = 0.ToString();
        }

        private void AddNumberToResult(double number)
        {
            if (char.IsNumber(result.Text.Last()))
            {
                if(result.Text.Length == 1 && result.Text == "0")
                {
                    result.Text = string.Empty;
                }
                result.Text += number;
            }
            else
            {
                if(number != 0)
                {
                    result.Text += number;
                }
            }
        }

        enum Operation { MINUS=1, PLUS=2, DIV=3, TIMES=4, NUMBER=5}
        private void AddOperationToResult(Operation operation)
        {
            if (result.Text.Length == 1 && result.Text == "0") return;
            if (!char.IsNumber(result.Text.Last()))
            {
                result.Text = result.Text.Substring(0, result.Text.Length - 1);
            }
            switch(operation)
            {
                case Operation.MINUS: result.Text += "-"; break;
                case Operation.PLUS: result.Text += "+"; break;
                case Operation.DIV: result.Text += "/"; break;
                case Operation.TIMES: result.Text += "x"; break;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(7);
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(8);
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(9);
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            AddOperationToResult(Operation.DIV);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(4);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(5);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(6);
        }

        private void btnTimes_Click(object sender, RoutedEventArgs e)
        {
            AddOperationToResult(Operation.TIMES);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(1);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(2);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(3);
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            AddOperationToResult(Operation.MINUS);
        }

        #region Equal

        private class Operand
        {
            public Operation operation = Operation.NUMBER; //default
            public double value = 0;

            public Operand left = null;
            public Operand righ = null;
        }

        private Operand BuildTreeOperand()
        {
            Operand tree = null;
            string expression = result.Text;
            if(!char.IsNumber(expression.Last()))
            {
                expression = expression.Substring(0, expression.Length - 1);
            }
            string numberStr = string.Empty;
            foreach(char c in expression.ToCharArray())
            {
                if(char.IsNumber(c) || c == '-' || numberStr == string.Empty && c =='-')
                {
                    numberStr += c;
                }
                else
                {
                    AddOperandToTree(ref tree, new Operand() { value = double.Parse(numberStr)});
                    numberStr = string.Empty;

                    Operation op = Operation.MINUS;
                    switch (c)
                    {
                        case '-': op = Operation.MINUS; break;
                        case '+': op = Operation.PLUS; break;
                        case '/': op = Operation.DIV; break;
                        case 'x': op = Operation.TIMES; break;
                    }
                    AddOperandToTree(ref tree, new Operand() { operation = op });
                }
            }
            AddOperandToTree(ref tree, new Operand() { value = double.Parse(numberStr) });
            return tree;
        }

        private void AddOperandToTree(ref Operand tree, Operand elem)
        {
            if(tree == null)
            {
                tree = elem;
            }
            else
            {
                if(elem.operation < tree.operation)
                {
                    Operand auxTree = tree;
                    tree = elem;
                    elem.left = auxTree;

                }
                else
                {
                    AddOperandToTree(ref tree.righ, elem);

                }
            }
        }

        private double Calc(Operand tree)
        {
            if(tree.left == null && tree.righ == null)
            {
                return tree.value;
            }
            else //verifica se existe uma operação a ser feita.
            {
               
                double subResult = 0;
                switch(tree.operation)
                {
                    //recursivo.
                    case Operation.MINUS: subResult = Calc(tree.left) - Calc(tree.righ); break;
                    case Operation.PLUS: subResult = Calc(tree.left) + Calc(tree.righ); break;
                    case Operation.DIV: subResult = Calc(tree.left) / Calc(tree.righ); break;
                    case Operation.TIMES: subResult = Calc(tree.left) * Calc(tree.righ); break;
                }
                return subResult;
            }
        }


        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(result.Text)) return;

            Operand tree = BuildTreeOperand();
            double value = Calc(tree);
            result.Text = value.ToString();
        }

        #endregion Equal

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(0);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            result.Text = 0.ToString();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            AddOperationToResult(Operation.PLUS);
        }
    }
}

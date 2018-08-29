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

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace GoNutsChallenge
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class CoffePage : Page
    {
        private string _roast;
        private string _sweetener;
        private string _cream;
        public CoffePage()
        {
            this.InitializeComponent();
        }

        private void Sweetener_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _roast = selected.Text;
            DisplayResult();
        }

        private void Roast_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _sweetener = selected.Text;
            DisplayResult();

        }

        private void Cream_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _cream = selected.Text;
            DisplayResult();
        }

        private void DisplayResult()
        {
            if(_roast == "None" || String.IsNullOrEmpty(_roast))
            {
                CoffeTextBox.Text = "None";
                return;
            }
            CoffeTextBox.Text = _roast;

            if(_cream == "None" || String.IsNullOrEmpty(_cream))
            {
                CoffeTextBox.Text = " + " +_cream;
            }

            if(_sweetener == "None" || String.IsNullOrEmpty(_sweetener))
            {
                CoffeTextBox.Text = " + " + _sweetener;
            }
        }
    }
}

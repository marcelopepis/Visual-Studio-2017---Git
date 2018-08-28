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

namespace HamburguerHeavenChallenger
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(Financial));
            SetTitle("Finalcial");
            FinancialListBoxItem.IsSelected = true;
            GoBack.Visibility = Visibility.Collapsed;

        }

        private void HamburguerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(FinancialListBoxItem.IsSelected)
            {
                GoBack.Visibility = Visibility.Collapsed;
                MyFrame.Navigate(typeof(Financial));
                SetTitle("Financial");
            }
            else if(FoodListBoxItem.IsSelected)
            {
                GoBack.Visibility = Visibility.Visible;
                MyFrame.Navigate(typeof(Food));
                SetTitle("Food");
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if(MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
                FinancialListBoxItem.IsSelected = true;
            }
        }

        private void SetTitle(String title)
        {
            TitleTextBox.Text = title;
        }
    }
}

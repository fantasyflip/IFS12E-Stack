using System;
using System.Collections.Generic;
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

namespace IFS12E
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CStack cs_s1 = null;
        const int ci_anzahl = 5;

        public MainWindow()
        {
            InitializeComponent();
            cs_s1 = new CStack(ci_anzahl);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr_input;

            mbr_input = MessageBox.Show("Soll das Programm wirklich beendet werden?", "Programm beenden", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (mbr_input == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void btnPush_Click(object sender, RoutedEventArgs e)
        {
            bool b_parse = false;
            int i_pushInt;
            bool b_PushResult;

            b_parse = int.TryParse(txtStackInput.Text, out i_pushInt);

            if (b_parse)
            {
                b_PushResult = cs_s1.Push(i_pushInt);

                if(b_PushResult)
                {
                    MessageBox.Show("Wert wurde gespeichert!", "Info - Push", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Wert wurde nicht gespeichert!", "Error - Push", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Fehler im Input-Feld", "Error - Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}

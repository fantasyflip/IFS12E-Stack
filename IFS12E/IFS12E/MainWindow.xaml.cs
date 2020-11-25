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
        private CStack cs_s1 = null;
        private const int ci_anzahl = 5;

        public MainWindow()
        {
            InitializeComponent();
            //Stack-Objekt erstellt
            cs_s1 = new CStack(ci_anzahl);
            cs_s1.setAnzeige(lstStack);
            lblStackSize.Content = "Stack-Größe: " + ci_anzahl;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr_input;

            mbr_input = MessageBox.Show("Soll das Programm wirklich beendet werden?", "Programm beenden", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            //Wenn Beenden-Frage bestätigt wird
            if (mbr_input == MessageBoxResult.OK)
            {
                //beenden
                this.Close();
            }
        }

        private void btnPush_Click(object sender, RoutedEventArgs e)
        {
            //lokale Variablen erstellt
            bool b_parse = false;
            int i_pushInt;
            bool b_PushResult;

            //Versuchen den Text in int zu casten
            b_parse = int.TryParse(txtStackInput.Text, out i_pushInt);

            //Wenn cast funtkioniert hat
            if (b_parse)
            {
                //Input speichern
                b_PushResult = cs_s1.Push(i_pushInt);

                //Wenn speichern funktioniert hat
                if(b_PushResult)
                {
                    MessageBox.Show("Wert wurde gespeichert!", "Info - Push", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtStackInput.Text = "";
                }
                //Wenn speichern nicht funktioniert
                else
                {
                    MessageBox.Show("Wert wurde nicht gespeichert!", "Error - Push", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            //Wenn cast nicht funtkioniert
            else
            {
                MessageBox.Show("Fehler im Input-Feld", "Error - Input", MessageBoxButton.OK, MessageBoxImage.Error);
                txtStackInput.Focus();
            }
            
        }

        private void btnPop_Click(object sender, RoutedEventArgs e)
        {
            //Lokale Variable erstellen
            int i_ergebnis;

            //Wenn Stack nicht leer
            if(!cs_s1.isEmpty())
            {
                //Ergebnis der Pop-Methode speichern
                i_ergebnis = cs_s1.Pop();

                MessageBox.Show("'" + i_ergebnis.ToString() + "' wurde vom Stack geholt!", "Info - Pop", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            //Wenn Stack leer
            else
            {
                MessageBox.Show("Der Stack enthält keine Werte!", "Error - Pop", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

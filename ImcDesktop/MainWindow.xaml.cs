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

namespace ImcDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            pesoTextBox.Focus();



        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            pesoTextBox.Text = "";
            estaturaTextBox.Text = "";
            imcTextBlock.Text = "0.0";
            imcTextBlock.Foreground = Brushes.Black;
            situacionTextBlock.Text = "";
            situacionTextBlock.Foreground = Brushes.Black;
            pesoTextBox.Focus();
        }

        private void calcularButton_Click(object sender, RoutedEventArgs e)
        {
            string s = pesoTextBox.Text;
            decimal peso = Convert.ToDecimal(s);
            s = estaturaTextBox.Text;
            decimal estatura = Convert.ToDecimal(s);
            decimal imc = peso / (estatura * estatura);
            imcTextBlock.Text = string.Format("{0:.0000}", imc);
            imcTextBlock.Foreground = SetColorEstadoNutricional(imc);
            situacionTextBlock.Text = EstadoNutricional(imc);
            situacionTextBlock.Foreground = SetColorEstadoNutricional(imc);
            limpiarButton.Focus();
        }

        private void salirButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private string EstadoNutricional(decimal imc)
        {
            if (imc < 18.5M)
            {
                return "Peso bajo";
            }
            else if (imc < 25.0M)
            {
                return "Peso normal";
            }
            else if (imc < 30.0M)
            {
                return "Sobrepeso";
            }
            else if (imc < 40.0M)
            {
                return "Obesidad";
            }
            else
            {
                return "Obesidad extrema";
            }
        }

        private Brush SetColorEstadoNutricional(decimal imc)
        {
            if (imc < 18.5M)
            {
                return Brushes.Yellow;
            }
            else if (imc < 25.0M)
            {
                return Brushes.Green;
            }
            else if (imc < 30.0M)
            {
                return Brushes.Yellow;
            }
            else if (imc < 40.0M)
            {
                return Brushes.Orange;
            }
            else
            {
                return Brushes.Red;
            }
        }

    }
}
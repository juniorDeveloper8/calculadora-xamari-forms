using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace zrcalculadora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private decimal primerNumero;
        private string nombreOperador;
        private bool isOperatorClicked; 

        // para q los nuemros se muestren en el panel
       /* private void BtnOne_Clicked(object sender, EventArgs e)
        {
            ZrcResult.Text ="1";
        }
       */

        //para poner todos los numeros en el panel
        private void BtnCommmon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (ZrcResult.Text == "0" || isOperatorClicked)
            {
                isOperatorClicked = false;
                ZrcResult.Text = button.Text;
            }
            else 
            {
                ZrcResult.Text += button.Text;
            }
        }
        //boton c para limpiar panel
        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            ZrcResult.Text="0";
        }
        //boton x borra un numero a la izquierda por si nos pasamos
        private void BtnX_Clicked(object sender, EventArgs e)
        {
            string number = ZrcResult.Text;

            if (number != "0") {
            
                number =number.Remove(number.Length - 1, 1);  
                
                if (string.IsNullOrEmpty(number)) {
                    
                    ZrcResult.Text = "0";
                }
                else
                {
                    ZrcResult.Text = number;
                }
            }
        }


        //boton de operacion

        private void BtnOperacion_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked = true;
            nombreOperador = button.Text;
            primerNumero = Convert.ToDecimal(ZrcResult.Text);
        }

        // boton de porcentaje
        private async void BtnPorcentaje_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number = ZrcResult.Text; 
                if (number != "0") {

                    decimal valorPorcentaje = Convert.ToDecimal(number);
                    string result = (valorPorcentaje / 100).ToString("0.##");
                    ZrcResult.Text = result;
                }
            }
            catch(Exception ex) {
                await DisplayAlert("Error",ex.Message,"ok");
            }

        }

        // boton igual para resultados
        private void BtnIgual_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal segundoNumero = Convert.ToDecimal(ZrcResult.Text);
                string finalResult = Calcular(primerNumero, segundoNumero).ToString("0.##");
                ZrcResult.Text = finalResult;
            }
            catch (Exception ex) {
                DisplayAlert("Error", ex.Message, "ok");
            }
        }

        // operaciones decimales

        public decimal Calcular(decimal primerNumero, decimal segundoNumero)
        {
            decimal result = 0;
            if (nombreOperador == "+")
            {
                result = primerNumero + segundoNumero;
            } 
            else if (nombreOperador == "-")
            {
                result = primerNumero - segundoNumero;
            } 
            else if (nombreOperador == "*")
            {
                result = primerNumero * segundoNumero;
            }
            else if (nombreOperador == "/")
            {
                result = primerNumero / segundoNumero;
            }
            return result;
        }
    }
}

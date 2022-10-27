using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiegoPenafiel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {

        String Usuario { get; set; }
        double CuotaMensualGuardada { get; set; }

        double TotalFinalCalculado { get; set; }

        String Estudiante { get; set; }
        public Registro(String usuario)
        {
            InitializeComponent();
            this.Usuario = usuario;
            usuarioLogeado.Text = usuario;
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            this.Usuario = "";
        }

        private void ValidarCuota(TextChangedEventArgs e, Entry entry)
        {
            if (e.NewTextValue != null && !e.NewTextValue.Equals(""))
            {
                try
                {
                    var valor = Double.Parse(e.NewTextValue);
                    if (valor < 1 || valor > 3000)
                    {
                        DisplayAlert("Advertencia", "La cuota inicial debe ser establecida entre 1 y 3000", "OK");
                        entry.Text = e.OldTextValue;
                    }
                    lblCuotaMensual.Text = "";
                    CuotaMensualGuardada = 0;
                    TotalFinalCalculado = 0;
                }
                catch
                {
                    DisplayAlert("Advertencia", "La cuota inicial debe ser establecida entre 1 y 3000", "OK");
                }
            }
        }

        private void cuotaInicial_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarCuota(e, cuotaInicial);
        }

        private void btnCalcularCuotaMensual_Clicked(object sender, EventArgs e)
        {
            if (txtNombreEstudiante.Text is null || txtNombreEstudiante.Text.Equals(""))
            {
                DisplayAlert("Error", "Primero ingresa el nombre del estudiante.", "OK");
                return;
            }

            if (cuotaInicial.Text is null ||cuotaInicial.Text.Equals(""))
            {
                DisplayAlert("Error", "Primero ingrese la cuota inicial.", "OK");
                return;
            }
            var cuotaInicialIngresada = Double.Parse(cuotaInicial.Text);
            var cuotaMensualCalculada = ((3000- cuotaInicialIngresada) /5)+(3000*0.05);
            DisplayAlert("Correcto", "Cuota mensual procesada con éxito.", "OK");
            lblCuotaMensual.Text = "$ "+cuotaMensualCalculada.ToString();
            CuotaMensualGuardada = cuotaMensualCalculada;
            TotalFinalCalculado = cuotaInicialIngresada + cuotaMensualCalculada*5;
            Estudiante = txtNombreEstudiante.Text.ToUpper();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (CuotaMensualGuardada>0) {
                DisplayAlert("Correcto", "Elemento guardado con éxito.", "OK");
                Navigation.PushAsync(new Resumen(this.Usuario, this.TotalFinalCalculado, this.Estudiante));
            }
            else
            {
                DisplayAlert("Error", "Cuota mensual aún no ha sido calculada.", "OK");
                return;
            }
        }
    }
}
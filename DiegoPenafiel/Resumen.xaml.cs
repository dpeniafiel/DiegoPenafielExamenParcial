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
    public partial class Resumen : ContentPage
    {

        String Usuario { get; set; }

        String Estudiante { get; set; }
        double totalFinalCalculado { get; set; }

        public Resumen(String usuario, double totalFinalCalculado, string estudiante)
        {
            InitializeComponent();
            this.Usuario = usuario;
            this.totalFinalCalculado = totalFinalCalculado;
            usuarioLogeado.Text = usuario;
            Estudiante = estudiante;
            MostrarResumen();
        }

        private void MostrarResumen()
        {
            lblEstudiante.Text = Estudiante;
            lblTotalFinal.Text = "$ "+totalFinalCalculado.ToString();
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
            this.Usuario = "";
        }
    }
}
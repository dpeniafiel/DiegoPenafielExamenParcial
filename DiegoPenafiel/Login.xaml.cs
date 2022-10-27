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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            String usuario = "diegoPenafiel2022";
            String clave = "uisrael2022";
            String usuarioIngresado = txtUsuario.Text;
            String claveIngresada = txtContrasena.Text;

            if (usuarioIngresado is null || claveIngresada is null)
            {
                DisplayAlert("Advertencia", "Ingresa los datos del usuario", "OK");
                return;
            }

            if (usuarioIngresado.Equals(usuario) && claveIngresada.Equals(clave))
            {
                DisplayAlert("Información", "Usuario logeado correctamente", "OK");
                Navigation.PushAsync(new Registro(usuario));
                return;
            }
            else
            {
                DisplayAlert("Advertencia", "Usuario o clave incorrectos", "OK");
                return;
            }
    }
    }
}
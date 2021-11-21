using AppTiendita.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTiendita
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private const string Url = "http://192.168.100.4/tiendas/post.php";
        private readonly HttpClient client = new HttpClient();
        public Login()
        {
            InitializeComponent();
        }

        private async void btnLoguear_Clicked(object sender, EventArgs e)
        {
            try
            {
                string correo = txtCorreo.Text;
                string password = txtPassword.Text;
                if (correo == null || password == null)
                {
                    await DisplayAlert("Mensaje", "Llenar todos los campos", "OK");
                }
                else
                {
                    var content = await client.GetStringAsync(Url + "?CORREOPROPIETARIO=" + correo + "&" + "CONTRASENAPROPIETARIO=" + password);

                    if (content.Equals("false"))
                    {
                        limpiarCampos();
                        await DisplayAlert("Mensaje", "Usuario o contraseña son incorrectos", "OK");
                    }
                    else
                    {
                        Propietario propietario = JsonConvert.DeserializeObject<Propietario>(content);
                        await Navigation.PushAsync(new Sucursales(propietario));
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje de advertencia", ex.Message, "OK");
            }
        }

        private void limpiarCampos()
        {
            txtCorreo.Text = "";
            txtPassword.Text = "";
        }
    }
}
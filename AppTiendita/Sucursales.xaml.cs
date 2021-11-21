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
    public partial class Sucursales : ContentPage
    {
        private const string Url = "http://192.168.100.4/tiendas/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Sucursal> _sucursales;
        public Sucursales(Propietario propietario)
        {
            InitializeComponent();
            cargarSucursales(propietario.idpropietario);
        }

        private async void cargarSucursales(int idPropietario)
        {
            try
            {
                var content = await client.GetStringAsync(Url+ "?IDPROPIETARIO="+ idPropietario);
                if (content.Equals("false")){
                    await DisplayAlert("Mensaje", "Error al obtener las sucursales", "OK");
                }
                else
                {
                    try
                    {
                        List<Sucursal> sucursales = JsonConvert.DeserializeObject<List<Sucursal>>(content);
                        _sucursales = new ObservableCollection<Sucursal>(sucursales);
                        MyListView.ItemsSource = _sucursales;
                        MyListView.ItemSelected += async (sender, e) =>
                        {
                            if (e.SelectedItem != null)
                            {
                               Sucursal sucursal = (Sucursal)e.SelectedItem;
                                await Navigation.PushAsync(new Menu(sucursal));
                            }
                        };
                    }
                    catch(Exception e)
                    {
                        Sucursal sucursal = JsonConvert.DeserializeObject<Sucursal>(content);
                        await Navigation.PushAsync(new Menu(sucursal));
                    }
                }

            }
            catch(Exception ex)
            {
                await DisplayAlert("Mensaje de advertencia", ex.Message, "OK");
            }
        }
    }
}
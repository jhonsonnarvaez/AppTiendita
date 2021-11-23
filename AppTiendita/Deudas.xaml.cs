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
    public partial class Deudas : ContentPage
    {
        private const string Url = "http://192.168.100.4/tiendas/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Deuda> _deuda;
        public Deudas()
        {

        }
        public Deudas(int idSucursal)
        {
            InitializeComponent();
            obtenerDeudas(idSucursal);
        }

        private async void obtenerDeudas(int idSucursal)
        {
            var content = await client.GetStringAsync(Url + "?IDSUCURSALES=" + idSucursal + "&DEUDAS");
            Deuda detalleDeuda;
            if (content.Equals("false"))
            {
                await DisplayAlert("Mensaje", "Error al obtener las deudas de los clientes", "OK");
            }
            else
            {
                List<Deuda> lstDeudas = JsonConvert.DeserializeObject<List<Deuda>>(content);
                _deuda = new ObservableCollection<Deuda>(lstDeudas);
                MyListViewDeuda.ItemsSource = _deuda;

                MyListViewDeuda.ItemSelected += async (sender, e) =>
                  {
                      if (e.SelectedItem != null)
                      {
                          detalleDeuda = (Deuda)e.SelectedItem;
                          await Navigation.PushAsync(new DetalleDeudas(detalleDeuda.idcliente));
                      }
                  };
            }
        }
    }
}
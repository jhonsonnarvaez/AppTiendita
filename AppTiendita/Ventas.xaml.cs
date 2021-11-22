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
    public partial class Ventas : ContentPage
    {
        private const string Url = "http://192.168.100.4/tiendas/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Venta> _venta;
        public Ventas()
        {

        }
        public Ventas(int idsucursal)
        {
            InitializeComponent();
            obtenerVentas(idsucursal);
        }

        private async void obtenerVentas(int idSucursal)
        {
            var content = await client.GetStringAsync(Url + "?idsucursal=" + idSucursal + "&VENTA");
            if (content.Equals("false"))
            {
                await DisplayAlert("Mensaje", "Error al obtener los clientes", "OK");
            }
            else
            {
                List<Venta> lstVentas = JsonConvert.DeserializeObject<List<Venta>>(content);
                _venta = new ObservableCollection<Venta>(lstVentas);
                MyListViewVenta.ItemsSource = _venta;
            }
        }
    }
}
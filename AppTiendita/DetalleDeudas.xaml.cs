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
    public partial class DetalleDeudas : ContentPage
    {
        private const string Url = "http://192.168.100.4/tiendas/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<DetalleDeuda> _deudaDet;
        public DetalleDeudas(int idcliente)
        {
            InitializeComponent();
            obtenerDetalleDeudas(idcliente);
        }

        private async void obtenerDetalleDeudas(int idCliente)
        {
            var content = await client.GetStringAsync(Url + "?IDCLIENTE=" + idCliente + "&DEUDAS");
            if (content.Equals("false"))
            {
                await DisplayAlert("Mensaje", "Error al obtener las deudas de los clientes", "OK");
            }
            else
            {
                List<DetalleDeuda> lstDetalleDeudas = JsonConvert.DeserializeObject<List<DetalleDeuda>>(content);
                _deudaDet = new ObservableCollection<DetalleDeuda>(lstDetalleDeudas);
                MyListViewDetalleDeuda.ItemsSource = _deudaDet;

            }
        }
    }
}
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
    public partial class Clientes : ContentPage
    {
        private const string Url = "http://192.168.100.4/tiendas/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Cliente> _cliente;
        public Clientes()
        {

        }
        public Clientes(int idsucursal)
        {
            InitializeComponent();
            obtenerClientes(idsucursal);
        }

        private async void obtenerClientes(int idSucursal)
        {
            var content = await client.GetStringAsync(Url + "?IDSUCURSAL=" + idSucursal);
            if (content.Equals("false"))
            {
                await DisplayAlert("Mensaje", "Error al obtener los clientes", "OK");
            }
            else
            {
                List<Cliente> lstClientes = JsonConvert.DeserializeObject<List<Cliente>>(content);
                _cliente = new ObservableCollection<Cliente>(lstClientes);
                MyListViewCliente.ItemsSource = _cliente;
            }
        }
    }
}
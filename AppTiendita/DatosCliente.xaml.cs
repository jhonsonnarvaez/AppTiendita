using AppTiendita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTiendita
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatosCliente : ContentPage
    {
        public DatosCliente(Cliente cliente)
        {
            InitializeComponent();
            txtNombre.Text = cliente.nombrecompleto;
            txtDireccion.Text = cliente.direccioncliente;
            txtTelefono.Text = cliente.telefonocliente + "/"+ cliente.celularcliente;
            txtIdentidad.Text = cliente.identificacioncliente;
            txtCorreo.Text = cliente.correocliente;
        }
    }
}
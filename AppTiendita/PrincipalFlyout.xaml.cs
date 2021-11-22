using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTiendita
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalFlyout : ContentPage
    {
        public ListView ListView;

        public PrincipalFlyout()
        {
            InitializeComponent();

            BindingContext = new PrincipalFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class PrincipalFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PrincipalFlyoutMenuItem> MenuItems { get; set; }

            public PrincipalFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<PrincipalFlyoutMenuItem>(new[]
                {
                    new PrincipalFlyoutMenuItem { Id = 0, Title = "Clientes",IconSource="user.png",TargetType=typeof(Clientes) },
                    new PrincipalFlyoutMenuItem { Id = 1, Title = "Ventas",IconSource="ventas.png",TargetType=typeof(Ventas) },
                    new PrincipalFlyoutMenuItem { Id = 2, Title = "Deudas",IconSource="lista.png",TargetType=typeof(Deudas) },
                    new PrincipalFlyoutMenuItem { Id = 3, Title = "Cerrar",IconSource="cerrar.png",TargetType=typeof(Login) }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
using System.ComponentModel;
using Xamarin.Forms;
using XamarinFormsCrud.ViewModels;

namespace XamarinFormsCrud.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
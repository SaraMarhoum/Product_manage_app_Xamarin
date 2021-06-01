using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinFormsCrud.Models;

namespace XamarinFormsCrud.Views
{
    public class DeleteProductPage : ContentPage
    {
        private ListView _listView;
        private Button _button;

        Product _product = new Product();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db1");


        public DeleteProductPage()
        {
            this.Title = "Modifier un produit";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Product>().OrderBy(x => x.nom).ToList();
            _listView.ItemSelected += _listView_ItemSelected;

            _button = new Button();
            _button.Text = "Supprimer";
            _button.BackgroundColor = Color.DarkBlue;
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<Product>().Delete(X => X.Id == _product.Id);

            await DisplayAlert(null, _product.nom + " " + "Supprimé", "OK");
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            _product = (Product)e.SelectedItem;

        }
    }
}
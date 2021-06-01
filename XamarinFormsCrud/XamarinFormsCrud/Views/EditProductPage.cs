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
    public class EditProductPage : ContentPage
    {
        private ListView _listView;
        private Entry _IdEntry;
        private Entry _nomEntry;
        private Entry _descriptionEntry;
        private Entry _prixEntry;
        //private Entry _photoEntry;
        private Button _button;

        Product _product = new Product();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db1");
        
        public EditProductPage()
        {
            this.Title = "Modifier un produit";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Product>().OrderBy(x => x.nom).ToList();
            _listView.ItemSelected += _listView_ItemSelected;

            stackLayout.Children.Add(_listView);

            _IdEntry = new Entry();
            _IdEntry.Placeholder = "ID";
            _IdEntry.IsVisible = false;
            stackLayout.Children.Add(_IdEntry);

            _nomEntry = new Entry();
            _nomEntry.Keyboard = Keyboard.Text;
            _nomEntry.Placeholder = "Nom du produit";
            stackLayout.Children.Add(_nomEntry);

            _descriptionEntry = new Entry();
            _descriptionEntry.Keyboard = Keyboard.Text;
            _descriptionEntry.Placeholder = "Déscription du produit";
            stackLayout.Children.Add(_descriptionEntry);

            _prixEntry = new Entry();
            _prixEntry.Keyboard = Keyboard.Text;
            _prixEntry.Placeholder = "Prix du produit";
            stackLayout.Children.Add(_prixEntry);

            //_photoEntry = new Entry();
            //_photoEntry.Keyboard = Keyboard.Text;
            //_photoEntry.Placeholder = "Photo du produit";
            //stackLayout.Children.Add(_photoEntry);

            _button = new Button();
            _button.Text = "Mettre à jour";
            _button.BackgroundColor = Color.DarkBlue;
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;

        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Product product = new Product()
            {
                Id = Convert.ToInt32(_IdEntry.Text),
                nom = _nomEntry.Text,
                description = _descriptionEntry.Text,
                prix = Int32.Parse(_prixEntry.Text),
                //Photo = _photoEntry.Text
            };

            db.Update(product);

            await DisplayAlert(null, _product.nom + " " + "modifié", "OK");

            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            _product = (Product)e.SelectedItem;
            _IdEntry.Text = _product.Id.ToString();
            _nomEntry.Text = _product.nom;
            _descriptionEntry.Text = _product.description;
            //_photoEntry.Text = _product.Photo;
            _prixEntry.Text = _product.prix.ToString() ;
        }
    }
}
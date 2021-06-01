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
    public class AddProductPage : ContentPage
    {
        private Entry _nomEntry;
        private Entry _descriptionEntry;
        private Entry _prixEntry;
        //private Entry _photoEntry;

        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db1");

        public AddProductPage()
        {
            this.Title = "Ajouter un produit";

            StackLayout stackLayout = new StackLayout();

            _nomEntry = new Entry();
            _nomEntry.Keyboard = Keyboard.Text;
            _nomEntry.Placeholder = "Nom du produit";
            stackLayout.Children.Add(_nomEntry);

            _descriptionEntry = new Entry();
            _descriptionEntry.Keyboard = Keyboard.Text;
            _descriptionEntry.Placeholder = "Description du produit";
            stackLayout.Children.Add(_descriptionEntry);

            _prixEntry = new Entry();
            _prixEntry.Keyboard = Keyboard.Text;
            _prixEntry.Placeholder = "Prix du produit";
            stackLayout.Children.Add(_prixEntry);

            //_photoEntry = new Entry();
            //_photoEntry.Keyboard = Keyboard.Text;
            //_photoEntry.Placeholder = "Photo du produit";
            //stackLayout.Children.Add(_photoEntry);

            _saveButton = new Button();
            _saveButton.Text = "Ajouter";
            _saveButton.BackgroundColor = Color.DarkBlue;
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Product>();

            var maxPK = db.Table<Product>().OrderByDescending(p => p.Id).FirstOrDefault();

            Product product = new Product()
            {
                Id = (maxPK == null ? 1 : maxPK.Id + 1),
                nom = _nomEntry.Text,
                description = _descriptionEntry.Text,
                prix = Int32.Parse(_prixEntry.Text),
                //Photo = _prixEntry.Text
            };

            db.Insert(product);
            await DisplayAlert(null, product.nom + " " + "Ajouté", "OK");
            await Navigation.PopAsync();
        }



    }
}
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
    public class GetAllProductsPage : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db1");

        public GetAllProductsPage()
        {
            this.Title = "Liste des produits";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Product>().OrderBy(x => x.nom).ToList();

            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
    }
}
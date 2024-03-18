using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JustSport
{
    public class ApplicationViewModel
    {
        ApplicationContext db = new ApplicationContext();

        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;

        public ObservableCollection<Product> Products {  get; set; }

           public ApplicationViewModel()
        {
            db.Database.EnsureCreated();
            db.Products.Load();
            Products = db.Products.Local.ToObservableCollection();
        }


        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand((o) =>
                    {
                        db.Products.Load(); 
                        AddProduct addProduct = new AddProduct(new Product());
                        addProduct.Show();
                        if (addProduct.ShowDialog() == true)
                        {
                            Product product = addProduct.Product;
                            db.Products.Add(product);
                            db.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }));
            }
        }


        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new RelayCommand((selectedItem) =>
                    {
                        Product? product = selectedItem as Product;
                        if (product == null) { return; }

                        Product pr = new Product
                        {
                            Id = product.Id,
                            Title = product.Title,
                            Quantity = product.Quantity,
                            Price = product.Price,
                            Category = product.Category
                        };

                        AddProduct addProduct = new AddProduct(pr);
                        if(addProduct.ShowDialog()==true)
                        {
                            product.Title = addProduct.Product.Title;
                            product.Quantity = addProduct.Product.Quantity;
                            product.Price = addProduct.Product.Price;
                            product.Category = addProduct.Product.Category;
                            db.Entry(product).State = EntityState.Modified;
                            db.SaveChanges();
                        }

                    }));
            }
        }

        public RelayCommand DeleteCommand 
        { 
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand((selectedItem) =>
                    {
                        Product product = selectedItem as Product;

                        if (product == null) { return; }
                        db.Products.Remove(product);
                        db.SaveChanges();
                    }));

            } 
        }


    }
}

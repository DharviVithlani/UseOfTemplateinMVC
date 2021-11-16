using BusinessLogic.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class Product
    {
        public static IEnumerable<uspGetAllProducts_Result> GetAllProducts()
        {
            exampleEntities db = new exampleEntities();
            var productDetails = db.uspGetAllProducts().ToList();
            return productDetails;
        }

        public static ProductData GetProductByProductId(int? id)
        {
            exampleEntities db = new exampleEntities();
            var productdata = new ProductData();
            var productDetails = db.Products.Where(m => m.ProductId == id).FirstOrDefault();
            productdata.ProductId = productDetails.ProductId;
            productdata.Title = productDetails.Title;
            productdata.Description = productDetails.Description;
            productdata.Price = productDetails.Price;
            productdata.ProductImage = productDetails.ProductImage;
            return productdata;
        }

        public static void AddUpdateProducts(ProductData obj)
        {
            exampleEntities db = new exampleEntities();
            if (obj.ProductId == 0)
            {
                var productdata = new DataAccess.Product();
                productdata.ProductId = obj.ProductId;
                productdata.Title = obj.Title;
                productdata.Description = obj.Description;
                productdata.Price = obj.Price;
                productdata.ProductImage = obj.ProductImage;
                db.Products.Add(productdata);
            }
            else
            {
                var productDetails = db.Products.Where(m => m.ProductId == obj.ProductId).FirstOrDefault();
                productDetails.Title = obj.Title;
                productDetails.Description = obj.Description;
                productDetails.Price = obj.Price;
                if (obj.ProductImage != null)
                {
                    productDetails.ProductImage = obj.ProductImage;
                }
                db.Entry(productDetails).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        public static DataAccess.Product DeleteProduct(int id)
        {
            exampleEntities db = new exampleEntities();
            var deleterow = db.Products.Where(m => m.ProductId == id).FirstOrDefault();
            if (deleterow != null)
            {
                db.Entry(deleterow).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return deleterow;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Linq;  // added manually by "Add Refrence -> Assemblies -> Framework"
using System.Data.SqlClient;
using ProductDetailsContracts;
using System.Data;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class ProductDetails : IProductDetails
{

    public Product GetProduct(string productID)
    {
        int ID = Int32.Parse(productID);

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = ".";
        builder.InitialCatalog = "northwind";
        builder.IntegratedSecurity = true;
        DataContext productsContext = new DataContext(builder.ConnectionString);

        Product product = (from p in productsContext.GetTable<Product>()
            where p.ProductID == ID
            select p).First();  //get 1st row 

        return product;
    }
}

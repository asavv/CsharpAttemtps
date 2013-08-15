using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductionInformation" in code, svc and config file together.
public class ProductInformation : IProductInformation
{
    public decimal HowMuchWillItCost(int productID, int howMany)
    {
        SqlConnection dataConnection = new SqlConnection();
        decimal totalCost = 0m;

        try
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".";
            builder.InitialCatalog = "northwind";
            builder.IntegratedSecurity = true;
            dataConnection.ConnectionString = builder.ConnectionString;
            dataConnection.Open();

            SqlCommand dataCommand = new SqlCommand();
            dataCommand.Connection = dataConnection;
            dataCommand.CommandType = CommandType.Text;
            dataCommand.CommandText = "SELECT UnitPrice FROM Products WHERE ProductID = @ProductID";

            SqlParameter productIDparameter = new SqlParameter("@ProductID", SqlDbType.Int);
            productIDparameter.Value = productID;
            dataCommand.Parameters.Add(productIDparameter);

            decimal? price = dataCommand.ExecuteScalar() as decimal?; // because decimal is a value type, it must include the modifier ? in case you want to attribute null to it.
            if (price.HasValue)
            {
                totalCost = price.Value*howMany;
            }
        }
        finally
        {
            dataConnection.Close();
        }

        return totalCost;
    }
}

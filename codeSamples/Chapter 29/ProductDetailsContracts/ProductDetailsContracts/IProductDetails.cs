using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ProductDetailsContracts
{
    [ServiceContract]
    public interface IProductDetails
    {
        [OperationContract]  //means that this method should be exposed as a Web method, and therefore, accessible to client applications.
        [WebGet(UriTemplate = "products/{productID}")] //webGet = logic retrieve operation, UriTemplate = specifies the format of the URL provided to invoke the operation. The identifier in the curly braces must match the name of hte parameter.
        Product GetProduct(string productID);
    }
}

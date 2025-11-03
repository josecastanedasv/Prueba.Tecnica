using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Creativa.Data.DTOs;

namespace Creativa.Services
{
    [ServiceContract]
    public interface INorthwindService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<CustomerDTO> GetCustomers();

        [OperationContract]
        List<OrderDTO> GetOrdersByCustomer(string customerId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<CustomerDTO> GetCustomersByCountry(CountryRequestDTO request);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
        void Options();
    }
}

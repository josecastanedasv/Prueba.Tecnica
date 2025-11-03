using System.Collections.Generic;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using Creativa.Data.DTOs;
using Creativa.Data.Repositories;

namespace Creativa.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class NorthwindService : INorthwindService
    {
        private readonly NorthwindRepository _repo = new NorthwindRepository();
        private readonly WebTrackerRepository _logger = new WebTrackerRepository();

        public List<CustomerDTO> GetCustomers()
        {
            AddCorsHeaders();
            LogRequest();
            return _repo.GetCustomers();
        }

        public List<OrderDTO> GetOrdersByCustomer(string customerId)
        {
            AddCorsHeaders();
            LogRequest();
            return _repo.GetOrdersByCustomer(customerId);
        }

        public List<CustomerDTO> GetCustomersByCountry(CountryRequestDTO request)
        {
            AddCorsHeaders();
            LogRequest();
            return _repo.GetCustomersByCountry(request.country);
        }

        public void Options()
        {
            AddCorsHeaders();
            LogRequest();
        }

        private void AddCorsHeaders()
        {
            var r = WebOperationContext.Current.OutgoingResponse;
            r.Headers.Add("Access-Control-Allow-Origin", "*");
            r.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            r.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
        }

        private void LogRequest()
        {
            string url = null;
            string ip = "UNKNOWN";

            if (HttpContext.Current?.Request != null)
            {
                ip = HttpContext.Current.Request.UserHostAddress;
                var wcfUrl = WebOperationContext.Current?.IncomingRequest?.UriTemplateMatch?.RequestUri?.ToString();
                url = !string.IsNullOrEmpty(wcfUrl) ? wcfUrl : HttpContext.Current.Request.RawUrl;
            }
            else
            {
                url = WebOperationContext.Current?.IncomingRequest?.UriTemplateMatch?.RequestUri?.ToString() ?? "UNKNOWN";
            }

            if (string.IsNullOrEmpty(url)) url = "UNKNOWN";

            _logger.Log(url, ip);
        }
    }
}

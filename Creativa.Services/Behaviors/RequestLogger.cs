using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Creativa.Data.Repositories;
using System.Web;

namespace Creativa.Services
{
    public class RequestLogger : IDispatchMessageInspector
    {
        private readonly WebTrackerRepository _tracker = new WebTrackerRepository();

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var url = HttpContext.Current?.Request?.Url?.ToString() ?? "UNKNOWN";
            var ip = HttpContext.Current?.Request?.UserHostAddress ?? "UNKNOWN";

            _tracker.Log(url, ip);
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState) { }
    }
}

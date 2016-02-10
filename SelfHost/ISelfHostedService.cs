using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace SelfHost
{
    [ServiceContract]
    public interface ISelfHostedService
    {
        [OperationContract]
        string DisplayHello(string name);

        [OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "GetClientToken", ResponseFormat = WebMessageFormat.Json)]
        string GetClientToken();

        [OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "PostTransaction", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool PostTransaction(string nonce_data, int amount, string transactionData);
    }
}

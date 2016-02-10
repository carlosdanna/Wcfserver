using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Braintree;

namespace SelfHost
{
    public class SelfHostedService : ISelfHostedService
    {
        BraintreeGateway gateway = new BraintreeGateway
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = "9gpdh4sq3crfqwq6",
            PublicKey = "hh2r92dgpf2j75fx",
            PrivateKey = "8d25d3a4ca69903fe96b59a1963be143"
        };

        public string DisplayHello(string name)
        {
            return string.Format("Hello, {0}", name);
        }


        public string GetClientToken()
        {
            string clientToken = gateway.ClientToken.generate();
            return clientToken;
        }

        public bool PostTransaction(string nonce_data, int amount, string transactionData)
        {
            var request = new TransactionRequest
            {
                Amount = amount,
                PaymentMethodNonce = nonce_data,
                CustomerId = "26193738",

                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true,
                    StoreInVault = true
                }

            };


            Result<Transaction> result = gateway.Transaction.Sale(request);
            return result.IsSuccess();
        }
    }
}
